﻿using CollapseLauncher.Helper;
using CollapseLauncher.Helper.StreamUtility;
using Hi3Helper;
using Hi3Helper.EncTool.Parser.AssetMetadata.SRMetadataAsset;
using Hi3Helper.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Hi3Helper.Locale;
using static Hi3Helper.Logger;

namespace CollapseLauncher
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal partial class StarRailCache
    {
        // ReSharper disable once UnusedParameter.Local
        private async Task<bool> Update(List<SRAsset> updateAssetIndex, List<SRAsset> assetIndex, CancellationToken token)
        {
            // Initialize new proxy-aware HttpClient
            using HttpClient client = new HttpClientBuilder<SocketsHttpHandler>()
                .UseLauncherConfig(_downloadThreadCount + _downloadThreadCountReserved)
                .SetUserAgent(_userAgent)
                .SetAllowedDecompression(DecompressionMethods.None)
                .Create();

            // Assign DownloadClient
            DownloadClient downloadClient = DownloadClient.CreateInstance(client);
            try
            {
                // Set IsProgressAllIndetermined as false and update the status 
                _status.IsProgressAllIndetermined = true;
                UpdateStatus();

                // Iterate the asset index and do update operation
                ObservableCollection<IAssetProperty> assetProperty = new ObservableCollection<IAssetProperty>(AssetEntry);
                
                var runningTask = new ConcurrentDictionary<(SRAsset, IAssetProperty), byte>();
                if (_isBurstDownloadEnabled)
                {
                    await Parallel.ForEachAsync(
                        PairEnumeratePropertyAndAssetIndexPackage(
#if ENABLEHTTPREPAIR    
                        EnforceHTTPSchemeToAssetIndex(updateAssetIndex)
#else
                        updateAssetIndex
#endif
                        , assetProperty),
                        new ParallelOptions { CancellationToken = token, MaxDegreeOfParallelism = _downloadThreadCount },
                        async (asset, innerToken) =>
                        {
                            if (!runningTask.TryAdd(asset, 0))
                            {
                                LogWriteLine($"Found duplicated task for {asset.AssetProperty.Name}! Skipping...", LogType.Warning, true);
                                return;
                            }
                            await UpdateCacheAsset(asset, downloadClient, _httpClient_UpdateAssetProgress, innerToken);
                            runningTask.Remove(asset, out _);
                        });
                }
                else
                {
                    foreach ((SRAsset, IAssetProperty) asset in
                        PairEnumeratePropertyAndAssetIndexPackage(
#if ENABLEHTTPREPAIR    
                        EnforceHTTPSchemeToAssetIndex(updateAssetIndex)
#else
                        updateAssetIndex
#endif
                        , assetProperty))
                    {
                        if (!runningTask.TryAdd(asset, 0))
                        {
                            LogWriteLine($"Found duplicated task for {asset.Item2.Name}! Skipping...", LogType.Warning, true);
                            continue;
                        }
                        await UpdateCacheAsset(asset, downloadClient, _httpClient_UpdateAssetProgress, token);
                        runningTask.Remove(asset, out _);
                    }
                }

                return true;
            }
            catch (TaskCanceledException) { throw; }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                LogWriteLine($"An error occured while updating cache file!\r\n{ex}", LogType.Error, true);
                throw;
            }
        }

        private async Task UpdateCacheAsset((SRAsset AssetIndex, IAssetProperty AssetProperty) asset, DownloadClient downloadClient, DownloadProgressDelegate downloadProgress, CancellationToken token)
        {
            // Increment total count and update the status
            _progressAllCountCurrent++;
            FileInfo fileInfo = new FileInfo(asset.AssetIndex.LocalName!).EnsureCreationOfDirectory().EnsureNoReadOnly();
            _status.ActivityStatus = string.Format(Lang._Misc.Downloading + " {0}: {1}", asset.AssetIndex.AssetType, Path.GetFileName(fileInfo.Name));
            UpdateAll();

            // Run download task
            await RunDownloadTask(asset.AssetIndex.Size, fileInfo, asset.AssetIndex.RemoteURL, downloadClient, downloadProgress, token);
            LogWriteLine($"Downloaded cache [T: {asset.AssetIndex.AssetType}]: {Path.GetFileName(fileInfo.Name)}", LogType.Default, true);

            // Remove Asset Entry display
            PopRepairAssetEntry(asset.AssetProperty);
        }
    }
}
