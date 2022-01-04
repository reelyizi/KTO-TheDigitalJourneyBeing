#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename T1>
struct VirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct GenericVirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct GenericInterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InvokerActionInvoker2;
template <typename T1, typename T2>
struct InvokerActionInvoker2<T1*, T2*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2)
	{
		void* params[2] = { p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3;
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3<T1*, T2*, T3*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3* p3)
	{
		void* params[3] = { p1, p2, p3 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};

// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>
struct Dictionary_2_t79BA378F246EFA4AD0AFFA017D788423CACA8638;
// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83;
// System.Char[]
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// PlayFab.AuthenticationModels.EntityKey
struct EntityKey_tFADF551D013525A30F2A6FB10A4FC4AF5F34278E;
// PlayFab.AuthenticationModels.EntityLineage
struct EntityLineage_tBB3BF8ABA70636A13AE3412CE723954A429EE67E;
// PlayFab.AuthenticationModels.GetEntityTokenRequest
struct GetEntityTokenRequest_t058F7E73EA27EED4A7E6A49B1FF0770354FF6E69;
// PlayFab.AuthenticationModels.GetEntityTokenResponse
struct GetEntityTokenResponse_tD3A2F286A2716332E695130B0DDE7F9E2E0DABAC;
// System.IAsyncResult
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// PlayFab.PlayFabAuthenticationContext
struct PlayFabAuthenticationContext_t221B79722A7A90BF01896A080CB0488FC0A9971A;
// PlayFab.SharedModels.PlayFabBaseModel
struct PlayFabBaseModel_t8A6DEC14EE30C2F52F3DDB7513B352300DC0EA0E;
// PlayFab.PlayFabError
struct PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23;
// PlayFab.SharedModels.PlayFabRequestCommon
struct PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D;
// PlayFab.SharedModels.PlayFabResultCommon
struct PlayFabResultCommon_t021FCFD75D498AB8A802ECE543435DCBFC333F40;
// System.String
struct String_t;
// System.Text.StringBuilder
struct StringBuilder_t;
// PlayFab.AuthenticationModels.ValidateEntityTokenRequest
struct ValidateEntityTokenRequest_t208B61B7A774BBC7B3CD46D9296ED0BC848DEA3B;
// PlayFab.AuthenticationModels.ValidateEntityTokenResponse
struct ValidateEntityTokenResponse_t3BF0DD16B7B0A2D37AF6A38E77CE63119EFCF7AE;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// PlayFab.Events.PlayFabEvents/PlayFabErrorEvent
struct PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3;

struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;

struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct Il2CppArrayBounds;

// PlayFab.SharedModels.PlayFabBaseModel
struct PlayFabBaseModel_t8A6DEC14EE30C2F52F3DDB7513B352300DC0EA0E  : public RuntimeObject
{
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Nullable`1<System.UInt32>
struct Nullable_1_tD043F01310E483091D0E9A5526C3425F13EF2099 
{
	// System.Boolean System.Nullable`1::hasValue
	bool ___hasValue_0;
	// T System.Nullable`1::value
	uint32_t ___value_1;
};

// System.DateTime
struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D 
{
	// System.UInt64 System.DateTime::_dateData
	uint64_t ____dateData_46;
};

struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_StaticFields
{
	// System.Int32[] System.DateTime::s_daysToMonth365
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___s_daysToMonth365_30;
	// System.Int32[] System.DateTime::s_daysToMonth366
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___s_daysToMonth366_31;
	// System.DateTime System.DateTime::MinValue
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___MinValue_32;
	// System.DateTime System.DateTime::MaxValue
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___MaxValue_33;
	// System.DateTime System.DateTime::UnixEpoch
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___UnixEpoch_34;
};

// PlayFab.AuthenticationModels.EntityKey
struct EntityKey_tFADF551D013525A30F2A6FB10A4FC4AF5F34278E  : public PlayFabBaseModel_t8A6DEC14EE30C2F52F3DDB7513B352300DC0EA0E
{
	// System.String PlayFab.AuthenticationModels.EntityKey::Id
	String_t* ___Id_0;
	// System.String PlayFab.AuthenticationModels.EntityKey::Type
	String_t* ___Type_1;
};

// PlayFab.AuthenticationModels.EntityLineage
struct EntityLineage_tBB3BF8ABA70636A13AE3412CE723954A429EE67E  : public PlayFabBaseModel_t8A6DEC14EE30C2F52F3DDB7513B352300DC0EA0E
{
	// System.String PlayFab.AuthenticationModels.EntityLineage::CharacterId
	String_t* ___CharacterId_0;
	// System.String PlayFab.AuthenticationModels.EntityLineage::GroupId
	String_t* ___GroupId_1;
	// System.String PlayFab.AuthenticationModels.EntityLineage::MasterPlayerAccountId
	String_t* ___MasterPlayerAccountId_2;
	// System.String PlayFab.AuthenticationModels.EntityLineage::NamespaceId
	String_t* ___NamespaceId_3;
	// System.String PlayFab.AuthenticationModels.EntityLineage::TitleId
	String_t* ___TitleId_4;
	// System.String PlayFab.AuthenticationModels.EntityLineage::TitlePlayerAccountId
	String_t* ___TitlePlayerAccountId_5;
};

// System.Enum
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};

struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticFields
{
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* ___enumSeperatorCharArray_0;
};
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// PlayFab.SharedModels.PlayFabRequestCommon
struct PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D  : public PlayFabBaseModel_t8A6DEC14EE30C2F52F3DDB7513B352300DC0EA0E
{
	// PlayFab.PlayFabAuthenticationContext PlayFab.SharedModels.PlayFabRequestCommon::AuthenticationContext
	PlayFabAuthenticationContext_t221B79722A7A90BF01896A080CB0488FC0A9971A* ___AuthenticationContext_0;
};

// PlayFab.SharedModels.PlayFabResultCommon
struct PlayFabResultCommon_t021FCFD75D498AB8A802ECE543435DCBFC333F40  : public PlayFabBaseModel_t8A6DEC14EE30C2F52F3DDB7513B352300DC0EA0E
{
	// PlayFab.SharedModels.PlayFabRequestCommon PlayFab.SharedModels.PlayFabResultCommon::Request
	PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___Request_0;
	// System.Object PlayFab.SharedModels.PlayFabResultCommon::CustomData
	RuntimeObject* ___CustomData_1;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=14
struct __StaticArrayInitTypeSizeU3D14_t9D86BCC3B9CF0C77C4379DDB6FFCD77CE5672D09 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D14_t9D86BCC3B9CF0C77C4379DDB6FFCD77CE5672D09__padding[14];
	};
};

// System.Nullable`1<System.DateTime>
struct Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC 
{
	// System.Boolean System.Nullable`1::hasValue
	bool ___hasValue_0;
	// T System.Nullable`1::value
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___value_1;
};

// <PrivateImplementationDetails>
struct U3CPrivateImplementationDetailsU3E_t35799B8F9E549902A8DD862EADDCF7DD7887890D  : public RuntimeObject
{
};

struct U3CPrivateImplementationDetailsU3E_t35799B8F9E549902A8DD862EADDCF7DD7887890D_StaticFields
{
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=14 <PrivateImplementationDetails>::F69AE5FA1B0683C4BF3EFAA06507D1A30F94E8AE3F1E87D87982A7BF7AF2CA9D
	__StaticArrayInitTypeSizeU3D14_t9D86BCC3B9CF0C77C4379DDB6FFCD77CE5672D09 ___F69AE5FA1B0683C4BF3EFAA06507D1A30F94E8AE3F1E87D87982A7BF7AF2CA9D_0;
};

// System.Delegate
struct Delegate_t  : public RuntimeObject
{
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject* ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.IntPtr System.Delegate::interp_method
	intptr_t ___interp_method_7;
	// System.IntPtr System.Delegate::interp_invoke_impl
	intptr_t ___interp_invoke_impl_8;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t* ___method_info_9;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t* ___original_method_info_10;
	// System.DelegateData System.Delegate::data
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_12;
};
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};

// PlayFab.AuthenticationModels.GetEntityTokenRequest
struct GetEntityTokenRequest_t058F7E73EA27EED4A7E6A49B1FF0770354FF6E69  : public PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D
{
	// System.Collections.Generic.Dictionary`2<System.String,System.String> PlayFab.AuthenticationModels.GetEntityTokenRequest::CustomTags
	Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___CustomTags_1;
	// PlayFab.AuthenticationModels.EntityKey PlayFab.AuthenticationModels.GetEntityTokenRequest::Entity
	EntityKey_tFADF551D013525A30F2A6FB10A4FC4AF5F34278E* ___Entity_2;
};

// PlayFab.AuthenticationModels.IdentifiedDeviceType
struct IdentifiedDeviceType_t65541DFCE9A831D2BAD258C4778A31E8122D48E8 
{
	// System.Int32 PlayFab.AuthenticationModels.IdentifiedDeviceType::value__
	int32_t ___value___2;
};

// PlayFab.AuthenticationModels.LoginIdentityProvider
struct LoginIdentityProvider_tB89733C53C7F4C20799B67F5A64737250D7BF6E9 
{
	// System.Int32 PlayFab.AuthenticationModels.LoginIdentityProvider::value__
	int32_t ___value___2;
};

// PlayFab.PlayFabErrorCode
struct PlayFabErrorCode_tA1C7DA5DC1B813AD1155F1A9D1D703E03EBC3520 
{
	// System.Int32 PlayFab.PlayFabErrorCode::value__
	int32_t ___value___2;
};

// PlayFab.AuthenticationModels.ValidateEntityTokenRequest
struct ValidateEntityTokenRequest_t208B61B7A774BBC7B3CD46D9296ED0BC848DEA3B  : public PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D
{
	// System.Collections.Generic.Dictionary`2<System.String,System.String> PlayFab.AuthenticationModels.ValidateEntityTokenRequest::CustomTags
	Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___CustomTags_1;
	// System.String PlayFab.AuthenticationModels.ValidateEntityTokenRequest::EntityToken
	String_t* ___EntityToken_2;
};

// System.Nullable`1<PlayFab.AuthenticationModels.IdentifiedDeviceType>
struct Nullable_1_t9AD8E1438E05D5BA0F423DA1263AFC5941A801B1 
{
	// System.Boolean System.Nullable`1::hasValue
	bool ___hasValue_0;
	// T System.Nullable`1::value
	int32_t ___value_1;
};

// System.Nullable`1<PlayFab.AuthenticationModels.LoginIdentityProvider>
struct Nullable_1_t77AB991F23E03305B5C1448C8B16EAF99B4397F2 
{
	// System.Boolean System.Nullable`1::hasValue
	bool ___hasValue_0;
	// T System.Nullable`1::value
	int32_t ___value_1;
};

// PlayFab.AuthenticationModels.GetEntityTokenResponse
struct GetEntityTokenResponse_tD3A2F286A2716332E695130B0DDE7F9E2E0DABAC  : public PlayFabResultCommon_t021FCFD75D498AB8A802ECE543435DCBFC333F40
{
	// PlayFab.AuthenticationModels.EntityKey PlayFab.AuthenticationModels.GetEntityTokenResponse::Entity
	EntityKey_tFADF551D013525A30F2A6FB10A4FC4AF5F34278E* ___Entity_2;
	// System.String PlayFab.AuthenticationModels.GetEntityTokenResponse::EntityToken
	String_t* ___EntityToken_3;
	// System.Nullable`1<System.DateTime> PlayFab.AuthenticationModels.GetEntityTokenResponse::TokenExpiration
	Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___TokenExpiration_4;
};

// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates_13;
};
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_13;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_13;
};

// PlayFab.PlayFabError
struct PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23  : public RuntimeObject
{
	// System.String PlayFab.PlayFabError::ApiEndpoint
	String_t* ___ApiEndpoint_0;
	// System.Int32 PlayFab.PlayFabError::HttpCode
	int32_t ___HttpCode_1;
	// System.String PlayFab.PlayFabError::HttpStatus
	String_t* ___HttpStatus_2;
	// PlayFab.PlayFabErrorCode PlayFab.PlayFabError::Error
	int32_t ___Error_3;
	// System.String PlayFab.PlayFabError::ErrorMessage
	String_t* ___ErrorMessage_4;
	// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>> PlayFab.PlayFabError::ErrorDetails
	Dictionary_2_t79BA378F246EFA4AD0AFFA017D788423CACA8638* ___ErrorDetails_5;
	// System.Object PlayFab.PlayFabError::CustomData
	RuntimeObject* ___CustomData_6;
	// System.Nullable`1<System.UInt32> PlayFab.PlayFabError::RetryAfterSeconds
	Nullable_1_tD043F01310E483091D0E9A5526C3425F13EF2099 ___RetryAfterSeconds_7;
};

struct PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23_ThreadStaticFields
{
	// System.Text.StringBuilder PlayFab.PlayFabError::_tempSb
	StringBuilder_t* ____tempSb_8;
};

// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C  : public MulticastDelegate_t
{
};

// PlayFab.AuthenticationModels.ValidateEntityTokenResponse
struct ValidateEntityTokenResponse_t3BF0DD16B7B0A2D37AF6A38E77CE63119EFCF7AE  : public PlayFabResultCommon_t021FCFD75D498AB8A802ECE543435DCBFC333F40
{
	// PlayFab.AuthenticationModels.EntityKey PlayFab.AuthenticationModels.ValidateEntityTokenResponse::Entity
	EntityKey_tFADF551D013525A30F2A6FB10A4FC4AF5F34278E* ___Entity_2;
	// System.Nullable`1<PlayFab.AuthenticationModels.IdentifiedDeviceType> PlayFab.AuthenticationModels.ValidateEntityTokenResponse::IdentifiedDeviceType
	Nullable_1_t9AD8E1438E05D5BA0F423DA1263AFC5941A801B1 ___IdentifiedDeviceType_3;
	// System.Nullable`1<PlayFab.AuthenticationModels.LoginIdentityProvider> PlayFab.AuthenticationModels.ValidateEntityTokenResponse::IdentityProvider
	Nullable_1_t77AB991F23E03305B5C1448C8B16EAF99B4397F2 ___IdentityProvider_4;
	// System.String PlayFab.AuthenticationModels.ValidateEntityTokenResponse::IdentityProviderIssuedId
	String_t* ___IdentityProviderIssuedId_5;
	// PlayFab.AuthenticationModels.EntityLineage PlayFab.AuthenticationModels.ValidateEntityTokenResponse::Lineage
	EntityLineage_tBB3BF8ABA70636A13AE3412CE723954A429EE67E* ___Lineage_6;
};

// PlayFab.Events.PlayFabEvents/PlayFabErrorEvent
struct PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3  : public MulticastDelegate_t
{
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771  : public RuntimeArray
{
	ALIGN_FIELD (8) Delegate_t* m_Items[1];

	inline Delegate_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};



// System.Void PlayFab.SharedModels.PlayFabBaseModel::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayFabBaseModel__ctor_mEB7DCE98193DC376F3422B1011C0DC17B2795E2E (PlayFabBaseModel_t8A6DEC14EE30C2F52F3DDB7513B352300DC0EA0E* __this, const RuntimeMethod* method) ;
// System.Void PlayFab.SharedModels.PlayFabRequestCommon::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayFabRequestCommon__ctor_m6A3F4FFAFCC90E4D69D376813DA32F302FB35C17 (PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* __this, const RuntimeMethod* method) ;
// System.Void PlayFab.SharedModels.PlayFabResultCommon::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayFabResultCommon__ctor_m045283BC3AF921586DC332AF1F5B96CBF85C3A46 (PlayFabResultCommon_t021FCFD75D498AB8A802ECE543435DCBFC333F40* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_Multicast(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	typedef void (*FunctionPointerType) (PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method);
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* currentDelegate = reinterpret_cast<PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3*>(delegatesToInvoke[i]);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)(currentDelegate, ___request0, ___error1, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_Open(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D*, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___request0, ___error1, method);
}
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_Closed(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (RuntimeObject*, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D*, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(__this->___m_target_2, ___request0, ___error1, method);
}
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenStaticInvoker(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	InvokerActionInvoker2< PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D*, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* >::Invoke(__this->___method_ptr_0, method, NULL, ___request0, ___error1);
}
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_ClosedStaticInvoker(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	InvokerActionInvoker3< RuntimeObject*, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D*, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___request0, ___error1);
}
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenVirtual(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	VirtualActionInvoker1< PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* >::Invoke(il2cpp_codegen_method_get_slot(method), ___request0, ___error1);
}
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenInterface(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	InterfaceActionInvoker1< PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___request0, ___error1);
}
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenGenericVirtual(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	GenericVirtualActionInvoker1< PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* >::Invoke(method, ___request0, ___error1);
}
void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenGenericInterface(PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method)
{
	GenericInterfaceActionInvoker1< PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* >::Invoke(method, ___request0, ___error1);
}
// System.Void PlayFab.Events.PlayFabEvents/PlayFabErrorEvent::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayFabErrorEvent__ctor_m2A7788530C700396124CAE117A7B8A8D830EE99B (PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int methodCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = methodCount == 2;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_Open;
			else
				__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_Closed;
	}
	else
	{
		bool isOpen = methodCount == 1;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_Open;
			}
		}
		else
		{
			__this->___invoke_impl_1 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_Closed;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038_Multicast;
}
// System.Void PlayFab.Events.PlayFabEvents/PlayFabErrorEvent::Invoke(PlayFab.SharedModels.PlayFabRequestCommon,PlayFab.PlayFabError)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayFabErrorEvent_Invoke_mC72A34EB21591A0DAA34836E22A89E7DA238D038 (PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, const RuntimeMethod* method);
	((FunctionPointerType)__this->___invoke_impl_1)(__this, ___request0, ___error1, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult PlayFab.Events.PlayFabEvents/PlayFabErrorEvent::BeginInvoke(PlayFab.SharedModels.PlayFabRequestCommon,PlayFab.PlayFabError,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* PlayFabErrorEvent_BeginInvoke_mD33FA45553968F664B9C7FA6DBF5ABF91F5D656C (PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, PlayFabRequestCommon_t42B97E9F405CF1969D1CB265129566E2657A654D* ___request0, PlayFabError_t085A18640C2631872C3888388E2BC667C7B09C23* ___error1, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback2, RuntimeObject* ___object3, const RuntimeMethod* method) 
{
	void *__d_args[3] = {0};
	__d_args[0] = ___request0;
	__d_args[1] = ___error1;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback2, (RuntimeObject*)___object3);;
}
// System.Void PlayFab.Events.PlayFabEvents/PlayFabErrorEvent::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayFabErrorEvent_EndInvoke_m25BF1B023D9883283109BA5E5F2BA6215F10308A (PlayFabErrorEvent_t32269E6C8CF3C5FF597C169C1CACE3D97D0E50C3* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void PlayFab.AuthenticationModels.EntityKey::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EntityKey__ctor_mB1488235600DA953B7B9CC3FEA6BD0B581CDBABD (EntityKey_tFADF551D013525A30F2A6FB10A4FC4AF5F34278E* __this, const RuntimeMethod* method) 
{
	{
		PlayFabBaseModel__ctor_mEB7DCE98193DC376F3422B1011C0DC17B2795E2E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void PlayFab.AuthenticationModels.EntityLineage::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EntityLineage__ctor_m702D59D688842FBEEA0556ADA6FF027B4C632DC3 (EntityLineage_tBB3BF8ABA70636A13AE3412CE723954A429EE67E* __this, const RuntimeMethod* method) 
{
	{
		PlayFabBaseModel__ctor_mEB7DCE98193DC376F3422B1011C0DC17B2795E2E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void PlayFab.AuthenticationModels.GetEntityTokenRequest::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GetEntityTokenRequest__ctor_m9B22427D71006B07D4EF7EE46CB3D3DEEC0B6CE9 (GetEntityTokenRequest_t058F7E73EA27EED4A7E6A49B1FF0770354FF6E69* __this, const RuntimeMethod* method) 
{
	{
		PlayFabRequestCommon__ctor_m6A3F4FFAFCC90E4D69D376813DA32F302FB35C17(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void PlayFab.AuthenticationModels.GetEntityTokenResponse::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GetEntityTokenResponse__ctor_m005FA6D3219909B9145CCA811B9EF14B76CC1D41 (GetEntityTokenResponse_tD3A2F286A2716332E695130B0DDE7F9E2E0DABAC* __this, const RuntimeMethod* method) 
{
	{
		PlayFabResultCommon__ctor_m045283BC3AF921586DC332AF1F5B96CBF85C3A46(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void PlayFab.AuthenticationModels.ValidateEntityTokenRequest::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ValidateEntityTokenRequest__ctor_m1CC2F8D79AD059413023EC9D83F2ECA04DF1AECA (ValidateEntityTokenRequest_t208B61B7A774BBC7B3CD46D9296ED0BC848DEA3B* __this, const RuntimeMethod* method) 
{
	{
		PlayFabRequestCommon__ctor_m6A3F4FFAFCC90E4D69D376813DA32F302FB35C17(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void PlayFab.AuthenticationModels.ValidateEntityTokenResponse::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ValidateEntityTokenResponse__ctor_m84808164C3ADB884CEB8B2E27FF7B2E206A37729 (ValidateEntityTokenResponse_t3BF0DD16B7B0A2D37AF6A38E77CE63119EFCF7AE* __this, const RuntimeMethod* method) 
{
	{
		PlayFabResultCommon__ctor_m045283BC3AF921586DC332AF1F5B96CBF85C3A46(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
