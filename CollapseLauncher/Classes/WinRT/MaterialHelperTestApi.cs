//------------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by cswinrt.exe version 2.2.0.241111.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WinRT;
using WinRT.Interop;


#pragma warning disable 0169 // warning CS0169: The field '...' is never used
#pragma warning disable 0649 // warning CS0169: Field '...' is never assigned to
#pragma warning disable CA2207, CA1063, CA1033, CA1001, CA2213

namespace Microsoft.UI.Private.Media
{
    [global::WinRT.WindowsRuntimeType("MaterialHelperTestApi")][Guid("FFEB6DAD-B1FC-56E7-9820-667BD14B4791")][global::WinRT.WindowsRuntimeHelperType(typeof(global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApi))]
    internal interface IMaterialHelperTestApi
    {
    }
    [global::WinRT.WindowsRuntimeType("MaterialHelperTestApi")][Guid("7FC11A83-CB9E-50B4-B4B3-645F08552BDA")][global::WinRT.WindowsRuntimeHelperType(typeof(global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiStatics))]
    internal interface IMaterialHelperTestApiStatics
    {
        bool IgnoreAreEffectsFast { get; set; }
        bool SimulateDisabledByPolicy { get; set; }
    }
    [global::WinRT.WindowsRuntimeType("MaterialHelperTestApi")]
    [global::WinRT.WindowsRuntimeHelperType(typeof(global::ABI.Microsoft.UI.Private.Media.MaterialHelperTestApi))]
    [global::ABI.Microsoft.UI.Private.Media.MaterialHelperTestApiRcwFactory]
    [global::WinRT.ProjectedRuntimeClass(typeof(IMaterialHelperTestApi))]
    public sealed class MaterialHelperTestApi : global::Microsoft.UI.Xaml.DependencyObject, global::System.Runtime.InteropServices.ICustomQueryInterface, IWinRTObject, IEquatable<MaterialHelperTestApi>
    {
        private IntPtr ThisPtr => _inner == null ? (((IWinRTObject)this).NativeObject).ThisPtr : _inner.ThisPtr;

        private readonly IObjectReference _inner = null;



        private IObjectReference _objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApi => _inner;


        private static volatile IObjectReference ___objRef_global__Microsoft_UI_Private_Media_MaterialHelperTestApi;
        private static IObjectReference _objRef_global__Microsoft_UI_Private_Media_MaterialHelperTestApi
        {
            get
            {
                var factory = ___objRef_global__Microsoft_UI_Private_Media_MaterialHelperTestApi;
                if (factory != null && factory.IsInCurrentContext)
                {
                    return factory;
                }
                else
                {
                    return ___objRef_global__Microsoft_UI_Private_Media_MaterialHelperTestApi = ActivationFactory.Get("Microsoft.UI.Private.Media.MaterialHelperTestApi");
                }
            }
        }

        public MaterialHelperTestApi() :base(global::WinRT.DerivedComposed.Instance)
        {
            _inner = global::ABI.WinRT.Interop.IActivationFactoryMethods.ActivateInstanceUnsafe(_objRef_global__Microsoft_UI_Private_Media_MaterialHelperTestApi, global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiMethods.IID);
            ComWrappersSupport.RegisterObjectForInterface(this, ThisPtr);
            ComWrappersHelper.Init(_inner, false);

        }

        public static I As<I>() => ActivationFactory.Get("Microsoft.UI.Private.Media.MaterialHelperTestApi").AsInterface<I>();

        private static volatile IObjectReference ___objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApiStatics;
        private static IObjectReference _objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApiStatics
        {
            get
            {
                var factory = ___objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApiStatics;
                if (factory != null && factory.IsInCurrentContext)
                {
                    return factory;
                }
                else
                {
                    return ___objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApiStatics = ActivationFactory.Get("Microsoft.UI.Private.Media.MaterialHelperTestApi", global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiStaticsMethods.IID);
                }
            }
        }

        public static bool IgnoreAreEffectsFast
        {
            get => global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiStaticsMethods.get_IgnoreAreEffectsFast(_objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApiStatics);
            set => global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiStaticsMethods.set_IgnoreAreEffectsFast(_objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApiStatics, value);
        }

        public static bool SimulateDisabledByPolicy
        {
            get => global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiStaticsMethods.get_SimulateDisabledByPolicy(_objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApiStatics);
            set => global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiStaticsMethods.set_SimulateDisabledByPolicy(_objRef_global__Microsoft_UI_Private_Media_IMaterialHelperTestApiStatics, value);
        }

        public static new MaterialHelperTestApi FromAbi(IntPtr thisPtr)
        {
            if (thisPtr == IntPtr.Zero) return null;
            return MarshalInspectable<MaterialHelperTestApi>.FromAbi(thisPtr);
        }

        internal MaterialHelperTestApi(IObjectReference objRef)
            : base(global::WinRT.DerivedComposed.Instance)

        {
            _inner = objRef.As(global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiMethods.IID);

        }


        public static bool operator ==(MaterialHelperTestApi x, MaterialHelperTestApi y) => (x?.ThisPtr ?? IntPtr.Zero) == (y?.ThisPtr ?? IntPtr.Zero);
        public static bool operator !=(MaterialHelperTestApi x, MaterialHelperTestApi y) => !(x == y);
        public bool Equals(MaterialHelperTestApi other) => this == other;
        public override bool Equals(object obj) => obj is MaterialHelperTestApi that && this == that;
        public override int GetHashCode() => ThisPtr.GetHashCode();


        bool IWinRTObject.HasUnwrappableNativeObject => true;
        IObjectReference IWinRTObject.NativeObject => _inner;

        private struct InterfaceTag<I>{};


        protected override bool IsOverridableInterface(Guid iid) => base.IsOverridableInterface(iid);

        global::System.Runtime.InteropServices.CustomQueryInterfaceResult global::System.Runtime.InteropServices.ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
        {
            ppv = IntPtr.Zero;
            if (IsOverridableInterface(iid) || global::WinRT.Interop.IID.IID_IInspectable == iid)
            {
                return global::System.Runtime.InteropServices.CustomQueryInterfaceResult.NotHandled;
            }

            if (((IWinRTObject)this).NativeObject.TryAs(iid, out ppv) >= 0)
            {
                return global::System.Runtime.InteropServices.CustomQueryInterfaceResult.Handled;
            }

            return global::System.Runtime.InteropServices.CustomQueryInterfaceResult.NotHandled;
        }
    }
}

#pragma warning disable CA1416
namespace ABI.Microsoft.UI.Private.Media
{
    internal static class IMaterialHelperTestApiMethods
    {



        public static ref readonly global::System.Guid IID
        {
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            get
            {
                global::System.ReadOnlySpan<byte> data = new byte[] { 0xAD, 0x6D, 0xEB, 0xFF, 0xFC, 0xB1, 0xE7, 0x56, 0x98, 0x20, 0x66, 0x7B, 0xD1, 0x4B, 0x47, 0x91 };
                return ref global::System.Runtime.CompilerServices.Unsafe.As<byte, global::System.Guid>(ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(data));
            }
        }

    }
    [Guid("FFEB6DAD-B1FC-56E7-9820-667BD14B4791")]
    internal interface IMaterialHelperTestApi : global::Microsoft.UI.Private.Media.IMaterialHelperTestApi
    {
    }
    internal static class IMaterialHelperTestApiStaticsMethods
    {

        internal static unsafe bool get_IgnoreAreEffectsFast(IObjectReference _obj)
        {
            var ThisPtr = _obj.ThisPtr;

            byte __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR((*(delegate* unmanaged[Stdcall]<IntPtr, byte*, int>**)ThisPtr)[8](ThisPtr, &__retval));
            global::System.GC.KeepAlive(_obj);
            return __retval != 0;
        }
        internal static unsafe void set_IgnoreAreEffectsFast(IObjectReference _obj, bool value)
        {
            var ThisPtr = _obj.ThisPtr;

            global::WinRT.ExceptionHelpers.ThrowExceptionForHR((*(delegate* unmanaged[Stdcall]<IntPtr, byte, int>**)ThisPtr)[9](ThisPtr, (byte)(value ? 1 : 0)));
            global::System.GC.KeepAlive(_obj);
        }

        internal static unsafe bool get_SimulateDisabledByPolicy(IObjectReference _obj)
        {
            var ThisPtr = _obj.ThisPtr;

            byte __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR((*(delegate* unmanaged[Stdcall]<IntPtr, byte*, int>**)ThisPtr)[6](ThisPtr, &__retval));
            global::System.GC.KeepAlive(_obj);
            return __retval != 0;
        }
        internal static unsafe void set_SimulateDisabledByPolicy(IObjectReference _obj, bool value)
        {
            var ThisPtr = _obj.ThisPtr;

            global::WinRT.ExceptionHelpers.ThrowExceptionForHR((*(delegate* unmanaged[Stdcall]<IntPtr, byte, int>**)ThisPtr)[7](ThisPtr, (byte)(value ? 1 : 0)));
            global::System.GC.KeepAlive(_obj);
        }



        public static ref readonly global::System.Guid IID
        {
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            get
            {
                global::System.ReadOnlySpan<byte> data = new byte[] { 0x83, 0x1A, 0xC1, 0x7F, 0x9E, 0xCB, 0xB4, 0x50, 0xB4, 0xB3, 0x64, 0x5F, 0x8, 0x55, 0x2B, 0xDA };
                return ref global::System.Runtime.CompilerServices.Unsafe.As<byte, global::System.Guid>(ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference(data));
            }
        }

    }
    [Guid("7FC11A83-CB9E-50B4-B4B3-645F08552BDA")]
    internal interface IMaterialHelperTestApiStatics : global::Microsoft.UI.Private.Media.IMaterialHelperTestApiStatics
    {
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public struct MaterialHelperTestApi
    {

        public static IObjectReference CreateMarshaler(global::Microsoft.UI.Private.Media.MaterialHelperTestApi obj) => obj is null ? null : MarshalInspectable<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.CreateMarshaler<IUnknownVftbl>(obj, global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiMethods.IID);
        public static ObjectReferenceValue CreateMarshaler2(global::Microsoft.UI.Private.Media.MaterialHelperTestApi obj) => MarshalInspectable<object>.CreateMarshaler2(obj, global::ABI.Microsoft.UI.Private.Media.IMaterialHelperTestApiMethods.IID);
        public static IntPtr GetAbi(IObjectReference value) => value is null ? IntPtr.Zero : MarshalInterfaceHelper<object>.GetAbi(value);
        public static global::Microsoft.UI.Private.Media.MaterialHelperTestApi FromAbi(IntPtr thisPtr) => global::Microsoft.UI.Private.Media.MaterialHelperTestApi.FromAbi(thisPtr);
        public static IntPtr FromManaged(global::Microsoft.UI.Private.Media.MaterialHelperTestApi obj) => obj is null ? IntPtr.Zero : CreateMarshaler2(obj).Detach();
        public static unsafe MarshalInterfaceHelper<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.MarshalerArray CreateMarshalerArray(global::Microsoft.UI.Private.Media.MaterialHelperTestApi[] array) => MarshalInterfaceHelper<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.CreateMarshalerArray2(array, (o) => CreateMarshaler2(o));
        public static (int length, IntPtr data) GetAbiArray(object box) => MarshalInterfaceHelper<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.GetAbiArray(box);
        public static unsafe global::Microsoft.UI.Private.Media.MaterialHelperTestApi[] FromAbiArray(object box) => MarshalInterfaceHelper<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.FromAbiArray(box, FromAbi);
        public static void CopyAbiArray(global::Microsoft.UI.Private.Media.MaterialHelperTestApi[] array, object box) => MarshalInterfaceHelper<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.CopyAbiArray(array, box, FromAbi);
        public static (int length, IntPtr data) FromManagedArray(global::Microsoft.UI.Private.Media.MaterialHelperTestApi[] array) => MarshalInterfaceHelper<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.FromManagedArray(array, (o) => FromManaged(o));
        public static void DisposeMarshaler(IObjectReference value) => MarshalInspectable<object>.DisposeMarshaler(value);
        public static void DisposeMarshalerArray(MarshalInterfaceHelper<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.MarshalerArray array) => MarshalInterfaceHelper<global::Microsoft.UI.Private.Media.MaterialHelperTestApi>.DisposeMarshalerArray(array);
        public static void DisposeAbi(IntPtr abi) => MarshalInspectable<object>.DisposeAbi(abi);
        public static unsafe void DisposeAbiArray(object box) => MarshalInspectable<object>.DisposeAbiArray(box);
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal sealed class MaterialHelperTestApiRcwFactoryAttribute : global::WinRT.WinRTImplementationTypeRcwFactoryAttribute
    {
        public override object CreateInstance(global::WinRT.IInspectable inspectable)
            => new global::Microsoft.UI.Private.Media.MaterialHelperTestApi(inspectable.ObjRef);
    }
}
#pragma warning restore CA1416
