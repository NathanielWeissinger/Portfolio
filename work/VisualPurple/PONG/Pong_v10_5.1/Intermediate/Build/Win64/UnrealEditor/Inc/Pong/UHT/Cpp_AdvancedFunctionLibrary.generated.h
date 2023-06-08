// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

// IWYU pragma: private, include "Cpp_AdvancedFunctionLibrary.h"
#include "UObject/ObjectMacros.h"
#include "UObject/ScriptMacros.h"

PRAGMA_DISABLE_DEPRECATION_WARNINGS
class AActor;
class USceneComponent;
class UStaticMeshComponent;
#ifdef PONG_Cpp_AdvancedFunctionLibrary_generated_h
#error "Cpp_AdvancedFunctionLibrary.generated.h already included, missing '#pragma once' in Cpp_AdvancedFunctionLibrary.h"
#endif
#define PONG_Cpp_AdvancedFunctionLibrary_generated_h

#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_SPARSE_DATA
#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_RPC_WRAPPERS \
 \
	DECLARE_FUNCTION(execSetHitDegreeChangeXY); \
	DECLARE_FUNCTION(execGetHitLocationRatioXY); \
	DECLARE_FUNCTION(execGetHitLocationRatioY); \
	DECLARE_FUNCTION(execGetHitLocationRatioX); \
	DECLARE_FUNCTION(execGetRelativeSize); \
	DECLARE_FUNCTION(execGetAngleBetweenVectors); \
	DECLARE_FUNCTION(execGetActorRelativeHitLocation); \
	DECLARE_FUNCTION(execGetRelativeHitLocation);


#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_RPC_WRAPPERS_NO_PURE_DECLS \
 \
	DECLARE_FUNCTION(execSetHitDegreeChangeXY); \
	DECLARE_FUNCTION(execGetHitLocationRatioXY); \
	DECLARE_FUNCTION(execGetHitLocationRatioY); \
	DECLARE_FUNCTION(execGetHitLocationRatioX); \
	DECLARE_FUNCTION(execGetRelativeSize); \
	DECLARE_FUNCTION(execGetAngleBetweenVectors); \
	DECLARE_FUNCTION(execGetActorRelativeHitLocation); \
	DECLARE_FUNCTION(execGetRelativeHitLocation);


#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_ACCESSORS
#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_INCLASS_NO_PURE_DECLS \
private: \
	static void StaticRegisterNativesUCpp_AdvancedFunctionLibrary(); \
	friend struct Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics; \
public: \
	DECLARE_CLASS(UCpp_AdvancedFunctionLibrary, UBlueprintFunctionLibrary, COMPILED_IN_FLAGS(0), CASTCLASS_None, TEXT("/Script/Pong"), NO_API) \
	DECLARE_SERIALIZER(UCpp_AdvancedFunctionLibrary)


#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_INCLASS \
private: \
	static void StaticRegisterNativesUCpp_AdvancedFunctionLibrary(); \
	friend struct Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics; \
public: \
	DECLARE_CLASS(UCpp_AdvancedFunctionLibrary, UBlueprintFunctionLibrary, COMPILED_IN_FLAGS(0), CASTCLASS_None, TEXT("/Script/Pong"), NO_API) \
	DECLARE_SERIALIZER(UCpp_AdvancedFunctionLibrary)


#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_STANDARD_CONSTRUCTORS \
	/** Standard constructor, called after all reflected properties have been initialized */ \
	NO_API UCpp_AdvancedFunctionLibrary(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get()); \
	DEFINE_DEFAULT_OBJECT_INITIALIZER_CONSTRUCTOR_CALL(UCpp_AdvancedFunctionLibrary) \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, UCpp_AdvancedFunctionLibrary); \
	DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(UCpp_AdvancedFunctionLibrary); \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API UCpp_AdvancedFunctionLibrary(UCpp_AdvancedFunctionLibrary&&); \
	NO_API UCpp_AdvancedFunctionLibrary(const UCpp_AdvancedFunctionLibrary&); \
public: \
	NO_API virtual ~UCpp_AdvancedFunctionLibrary();


#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_ENHANCED_CONSTRUCTORS \
	/** Standard constructor, called after all reflected properties have been initialized */ \
	NO_API UCpp_AdvancedFunctionLibrary(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get()) : Super(ObjectInitializer) { }; \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API UCpp_AdvancedFunctionLibrary(UCpp_AdvancedFunctionLibrary&&); \
	NO_API UCpp_AdvancedFunctionLibrary(const UCpp_AdvancedFunctionLibrary&); \
public: \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, UCpp_AdvancedFunctionLibrary); \
	DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(UCpp_AdvancedFunctionLibrary); \
	DEFINE_DEFAULT_OBJECT_INITIALIZER_CONSTRUCTOR_CALL(UCpp_AdvancedFunctionLibrary) \
	NO_API virtual ~UCpp_AdvancedFunctionLibrary();


#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_15_PROLOG
#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_GENERATED_BODY_LEGACY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_SPARSE_DATA \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_RPC_WRAPPERS \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_ACCESSORS \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_INCLASS \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_STANDARD_CONSTRUCTORS \
public: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


#define FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_GENERATED_BODY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_SPARSE_DATA \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_RPC_WRAPPERS_NO_PURE_DECLS \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_ACCESSORS \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_INCLASS_NO_PURE_DECLS \
	FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_18_ENHANCED_CONSTRUCTORS \
private: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


template<> PONG_API UClass* StaticClass<class UCpp_AdvancedFunctionLibrary>();

#undef CURRENT_FILE_ID
#define CURRENT_FILE_ID FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h


PRAGMA_ENABLE_DEPRECATION_WARNINGS
