// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "Pong/Public/Cpp_AdvancedFunctionLibrary.h"
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeCpp_AdvancedFunctionLibrary() {}
// Cross Module References
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FVector();
	ENGINE_API UClass* Z_Construct_UClass_AActor_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UBlueprintFunctionLibrary();
	ENGINE_API UClass* Z_Construct_UClass_USceneComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UStaticMeshComponent_NoRegister();
	PONG_API UClass* Z_Construct_UClass_UCpp_AdvancedFunctionLibrary();
	PONG_API UClass* Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_NoRegister();
	UPackage* Z_Construct_UPackage__Script_Pong();
// End Cross Module References
	DEFINE_FUNCTION(UCpp_AdvancedFunctionLibrary::execSetHitDegreeChangeXY)
	{
		P_GET_OBJECT(AActor,Z_Param_Target);
		P_GET_OBJECT(UStaticMeshComponent,Z_Param_StaticMesh);
		P_GET_STRUCT(FVector,Z_Param_HitNormal);
		P_GET_STRUCT(FVector,Z_Param_RelativeHitLocation);
		P_GET_STRUCT_REF(FVector,Z_Param_Out_NewTargetVector);
		P_GET_PROPERTY(FFloatProperty,Z_Param_DegreeChangeRatio);
		P_FINISH;
		P_NATIVE_BEGIN;
		UCpp_AdvancedFunctionLibrary::SetHitDegreeChangeXY(Z_Param_Target,Z_Param_StaticMesh,Z_Param_HitNormal,Z_Param_RelativeHitLocation,Z_Param_Out_NewTargetVector,Z_Param_DegreeChangeRatio);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(UCpp_AdvancedFunctionLibrary::execGetHitLocationRatioXY)
	{
		P_GET_OBJECT(USceneComponent,Z_Param_Target);
		P_GET_STRUCT(FVector,Z_Param_RelativeHitLocation);
		P_GET_PROPERTY_REF(FFloatProperty,Z_Param_Out_HLR);
		P_FINISH;
		P_NATIVE_BEGIN;
		UCpp_AdvancedFunctionLibrary::GetHitLocationRatioXY(Z_Param_Target,Z_Param_RelativeHitLocation,Z_Param_Out_HLR);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(UCpp_AdvancedFunctionLibrary::execGetHitLocationRatioY)
	{
		P_GET_OBJECT(USceneComponent,Z_Param_Target);
		P_GET_STRUCT(FVector,Z_Param_RelativeHitLocation);
		P_GET_PROPERTY_REF(FFloatProperty,Z_Param_Out_HLRY);
		P_FINISH;
		P_NATIVE_BEGIN;
		UCpp_AdvancedFunctionLibrary::GetHitLocationRatioY(Z_Param_Target,Z_Param_RelativeHitLocation,Z_Param_Out_HLRY);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(UCpp_AdvancedFunctionLibrary::execGetHitLocationRatioX)
	{
		P_GET_OBJECT(USceneComponent,Z_Param_Target);
		P_GET_STRUCT(FVector,Z_Param_RelativeHitLocation);
		P_GET_PROPERTY_REF(FFloatProperty,Z_Param_Out_HLRX);
		P_FINISH;
		P_NATIVE_BEGIN;
		UCpp_AdvancedFunctionLibrary::GetHitLocationRatioX(Z_Param_Target,Z_Param_RelativeHitLocation,Z_Param_Out_HLRX);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(UCpp_AdvancedFunctionLibrary::execGetRelativeSize)
	{
		P_GET_OBJECT(UStaticMeshComponent,Z_Param_Target);
		P_GET_STRUCT_REF(FVector,Z_Param_Out_RelativeSize);
		P_FINISH;
		P_NATIVE_BEGIN;
		UCpp_AdvancedFunctionLibrary::GetRelativeSize(Z_Param_Target,Z_Param_Out_RelativeSize);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(UCpp_AdvancedFunctionLibrary::execGetAngleBetweenVectors)
	{
		P_GET_STRUCT(FVector,Z_Param_Vector1);
		P_GET_STRUCT(FVector,Z_Param_Vector2);
		P_GET_PROPERTY_REF(FFloatProperty,Z_Param_Out_Angle);
		P_FINISH;
		P_NATIVE_BEGIN;
		UCpp_AdvancedFunctionLibrary::GetAngleBetweenVectors(Z_Param_Vector1,Z_Param_Vector2,Z_Param_Out_Angle);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(UCpp_AdvancedFunctionLibrary::execGetActorRelativeHitLocation)
	{
		P_GET_STRUCT(FVector,Z_Param_WorldHitLocation);
		P_GET_OBJECT(USceneComponent,Z_Param_Target);
		P_GET_STRUCT_REF(FVector,Z_Param_Out_RelativeHitLocation);
		P_FINISH;
		P_NATIVE_BEGIN;
		UCpp_AdvancedFunctionLibrary::GetActorRelativeHitLocation(Z_Param_WorldHitLocation,Z_Param_Target,Z_Param_Out_RelativeHitLocation);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(UCpp_AdvancedFunctionLibrary::execGetRelativeHitLocation)
	{
		P_GET_STRUCT(FVector,Z_Param_WorldHitLocation);
		P_GET_STRUCT(FVector,Z_Param_WorldOriginLocation);
		P_GET_STRUCT_REF(FVector,Z_Param_Out_RelativeHitLocation);
		P_FINISH;
		P_NATIVE_BEGIN;
		UCpp_AdvancedFunctionLibrary::GetRelativeHitLocation(Z_Param_WorldHitLocation,Z_Param_WorldOriginLocation,Z_Param_Out_RelativeHitLocation);
		P_NATIVE_END;
	}
	void UCpp_AdvancedFunctionLibrary::StaticRegisterNativesUCpp_AdvancedFunctionLibrary()
	{
		UClass* Class = UCpp_AdvancedFunctionLibrary::StaticClass();
		static const FNameNativePtrPair Funcs[] = {
			{ "GetActorRelativeHitLocation", &UCpp_AdvancedFunctionLibrary::execGetActorRelativeHitLocation },
			{ "GetAngleBetweenVectors", &UCpp_AdvancedFunctionLibrary::execGetAngleBetweenVectors },
			{ "GetHitLocationRatioX", &UCpp_AdvancedFunctionLibrary::execGetHitLocationRatioX },
			{ "GetHitLocationRatioXY", &UCpp_AdvancedFunctionLibrary::execGetHitLocationRatioXY },
			{ "GetHitLocationRatioY", &UCpp_AdvancedFunctionLibrary::execGetHitLocationRatioY },
			{ "GetRelativeHitLocation", &UCpp_AdvancedFunctionLibrary::execGetRelativeHitLocation },
			{ "GetRelativeSize", &UCpp_AdvancedFunctionLibrary::execGetRelativeSize },
			{ "SetHitDegreeChangeXY", &UCpp_AdvancedFunctionLibrary::execSetHitDegreeChangeXY },
		};
		FNativeFunctionRegistrar::RegisterFunctions(Class, Funcs, UE_ARRAY_COUNT(Funcs));
	}
	struct Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics
	{
		struct Cpp_AdvancedFunctionLibrary_eventGetActorRelativeHitLocation_Parms
		{
			FVector WorldHitLocation;
			const USceneComponent* Target;
			FVector RelativeHitLocation;
		};
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_WorldHitLocation_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_WorldHitLocation;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_Target_MetaData[];
#endif
		static const UECodeGen_Private::FObjectPropertyParams NewProp_Target;
		static const UECodeGen_Private::FStructPropertyParams NewProp_RelativeHitLocation;
		static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UECodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_WorldHitLocation_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_WorldHitLocation = { "WorldHitLocation", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetActorRelativeHitLocation_Parms, WorldHitLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_WorldHitLocation_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_WorldHitLocation_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_Target_MetaData[] = {
		{ "EditInline", "true" },
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FObjectPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_Target = { "Target", nullptr, (EPropertyFlags)0x0010000000080082, UECodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetActorRelativeHitLocation_Parms, Target), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_Target_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_Target_MetaData)) };
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_RelativeHitLocation = { "RelativeHitLocation", nullptr, (EPropertyFlags)0x0010000000000180, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetActorRelativeHitLocation_Parms, RelativeHitLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(nullptr, 0) };
	const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::PropPointers[] = {
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_WorldHitLocation,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_Target,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::NewProp_RelativeHitLocation,
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::Function_MetaDataParams[] = {
		{ "Category", "Math|Vector" },
		{ "Comment", "//Returns FVector hit location relative to object origin\n" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
		{ "ToolTip", "Returns FVector hit location relative to object origin" },
	};
#endif
	const UECodeGen_Private::FFunctionParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, nullptr, "GetActorRelativeHitLocation", nullptr, nullptr, sizeof(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::Cpp_AdvancedFunctionLibrary_eventGetActorRelativeHitLocation_Parms), Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::PropPointers), RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04C42401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UECodeGen_Private::ConstructUFunction(&ReturnFunction, Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics
	{
		struct Cpp_AdvancedFunctionLibrary_eventGetAngleBetweenVectors_Parms
		{
			FVector Vector1;
			FVector Vector2;
			float Angle;
		};
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_Vector1_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_Vector1;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_Vector2_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_Vector2;
		static const UECodeGen_Private::FFloatPropertyParams NewProp_Angle;
		static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UECodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector1_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector1 = { "Vector1", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetAngleBetweenVectors_Parms, Vector1), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector1_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector1_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector2_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector2 = { "Vector2", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetAngleBetweenVectors_Parms, Vector2), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector2_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector2_MetaData)) };
	const UECodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Angle = { "Angle", nullptr, (EPropertyFlags)0x0010000000000180, UECodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetAngleBetweenVectors_Parms, Angle), METADATA_PARAMS(nullptr, 0) };
	const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::PropPointers[] = {
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector1,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Vector2,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::NewProp_Angle,
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::Function_MetaDataParams[] = {
		{ "Category", "Math|Vector" },
		{ "Comment", "//Returns float of angle in degrees between two vectors in 3D space\n" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
		{ "ToolTip", "Returns float of angle in degrees between two vectors in 3D space" },
	};
#endif
	const UECodeGen_Private::FFunctionParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, nullptr, "GetAngleBetweenVectors", nullptr, nullptr, sizeof(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::Cpp_AdvancedFunctionLibrary_eventGetAngleBetweenVectors_Parms), Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::PropPointers), RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04C42401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UECodeGen_Private::ConstructUFunction(&ReturnFunction, Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics
	{
		struct Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioX_Parms
		{
			const USceneComponent* Target;
			FVector RelativeHitLocation;
			float HLRX;
		};
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_Target_MetaData[];
#endif
		static const UECodeGen_Private::FObjectPropertyParams NewProp_Target;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_RelativeHitLocation_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_RelativeHitLocation;
		static const UECodeGen_Private::FFloatPropertyParams NewProp_HLRX;
		static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UECodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_Target_MetaData[] = {
		{ "EditInline", "true" },
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FObjectPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_Target = { "Target", nullptr, (EPropertyFlags)0x0010000000080082, UECodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioX_Parms, Target), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_Target_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_Target_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_RelativeHitLocation_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_RelativeHitLocation = { "RelativeHitLocation", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioX_Parms, RelativeHitLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_RelativeHitLocation_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_RelativeHitLocation_MetaData)) };
	const UECodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_HLRX = { "HLRX", nullptr, (EPropertyFlags)0x0010000000000180, UECodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioX_Parms, HLRX), METADATA_PARAMS(nullptr, 0) };
	const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::PropPointers[] = {
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_Target,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_RelativeHitLocation,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::NewProp_HLRX,
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::Function_MetaDataParams[] = {
		{ "Category", "Physics|Constraints" },
		{ "Comment", "//Returns value between 1 and -1 of X-axis hit location on XY plane\n" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
		{ "ToolTip", "Returns value between 1 and -1 of X-axis hit location on XY plane" },
	};
#endif
	const UECodeGen_Private::FFunctionParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, nullptr, "GetHitLocationRatioX", nullptr, nullptr, sizeof(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioX_Parms), Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::PropPointers), RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04C42401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UECodeGen_Private::ConstructUFunction(&ReturnFunction, Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics
	{
		struct Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioXY_Parms
		{
			const USceneComponent* Target;
			FVector RelativeHitLocation;
			float HLR;
		};
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_Target_MetaData[];
#endif
		static const UECodeGen_Private::FObjectPropertyParams NewProp_Target;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_RelativeHitLocation_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_RelativeHitLocation;
		static const UECodeGen_Private::FFloatPropertyParams NewProp_HLR;
		static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UECodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_Target_MetaData[] = {
		{ "EditInline", "true" },
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FObjectPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_Target = { "Target", nullptr, (EPropertyFlags)0x0010000000080082, UECodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioXY_Parms, Target), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_Target_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_Target_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_RelativeHitLocation_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_RelativeHitLocation = { "RelativeHitLocation", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioXY_Parms, RelativeHitLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_RelativeHitLocation_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_RelativeHitLocation_MetaData)) };
	const UECodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_HLR = { "HLR", nullptr, (EPropertyFlags)0x0010000000000180, UECodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioXY_Parms, HLR), METADATA_PARAMS(nullptr, 0) };
	const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::PropPointers[] = {
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_Target,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_RelativeHitLocation,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::NewProp_HLR,
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::Function_MetaDataParams[] = {
		{ "Category", "Physics|Constraints" },
		{ "Comment", "//Returns value between 1 and -1 of 2D hit location on XY plane\n" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
		{ "ToolTip", "Returns value between 1 and -1 of 2D hit location on XY plane" },
	};
#endif
	const UECodeGen_Private::FFunctionParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, nullptr, "GetHitLocationRatioXY", nullptr, nullptr, sizeof(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioXY_Parms), Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::PropPointers), RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04C42401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UECodeGen_Private::ConstructUFunction(&ReturnFunction, Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics
	{
		struct Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioY_Parms
		{
			const USceneComponent* Target;
			FVector RelativeHitLocation;
			float HLRY;
		};
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_Target_MetaData[];
#endif
		static const UECodeGen_Private::FObjectPropertyParams NewProp_Target;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_RelativeHitLocation_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_RelativeHitLocation;
		static const UECodeGen_Private::FFloatPropertyParams NewProp_HLRY;
		static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UECodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_Target_MetaData[] = {
		{ "EditInline", "true" },
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FObjectPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_Target = { "Target", nullptr, (EPropertyFlags)0x0010000000080082, UECodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioY_Parms, Target), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_Target_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_Target_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_RelativeHitLocation_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_RelativeHitLocation = { "RelativeHitLocation", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioY_Parms, RelativeHitLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_RelativeHitLocation_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_RelativeHitLocation_MetaData)) };
	const UECodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_HLRY = { "HLRY", nullptr, (EPropertyFlags)0x0010000000000180, UECodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioY_Parms, HLRY), METADATA_PARAMS(nullptr, 0) };
	const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::PropPointers[] = {
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_Target,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_RelativeHitLocation,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::NewProp_HLRY,
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::Function_MetaDataParams[] = {
		{ "Category", "Physics|Constraints" },
		{ "Comment", "//Returns value between 1 and -1 of Y-axis hit location on XY plane\n" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
		{ "ToolTip", "Returns value between 1 and -1 of Y-axis hit location on XY plane" },
	};
#endif
	const UECodeGen_Private::FFunctionParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, nullptr, "GetHitLocationRatioY", nullptr, nullptr, sizeof(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::Cpp_AdvancedFunctionLibrary_eventGetHitLocationRatioY_Parms), Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::PropPointers), RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04C42401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UECodeGen_Private::ConstructUFunction(&ReturnFunction, Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics
	{
		struct Cpp_AdvancedFunctionLibrary_eventGetRelativeHitLocation_Parms
		{
			FVector WorldHitLocation;
			FVector WorldOriginLocation;
			FVector RelativeHitLocation;
		};
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_WorldHitLocation_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_WorldHitLocation;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_WorldOriginLocation_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_WorldOriginLocation;
		static const UECodeGen_Private::FStructPropertyParams NewProp_RelativeHitLocation;
		static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UECodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldHitLocation_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldHitLocation = { "WorldHitLocation", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetRelativeHitLocation_Parms, WorldHitLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldHitLocation_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldHitLocation_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldOriginLocation_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldOriginLocation = { "WorldOriginLocation", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetRelativeHitLocation_Parms, WorldOriginLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldOriginLocation_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldOriginLocation_MetaData)) };
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_RelativeHitLocation = { "RelativeHitLocation", nullptr, (EPropertyFlags)0x0010000000000180, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetRelativeHitLocation_Parms, RelativeHitLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(nullptr, 0) };
	const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::PropPointers[] = {
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldHitLocation,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_WorldOriginLocation,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::NewProp_RelativeHitLocation,
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::Function_MetaDataParams[] = {
		{ "Category", "Math|Vector" },
		{ "Comment", "//Returns FVector hit location relative to object origin\n" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
		{ "ToolTip", "Returns FVector hit location relative to object origin" },
	};
#endif
	const UECodeGen_Private::FFunctionParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, nullptr, "GetRelativeHitLocation", nullptr, nullptr, sizeof(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::Cpp_AdvancedFunctionLibrary_eventGetRelativeHitLocation_Parms), Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::PropPointers), RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04C42401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UECodeGen_Private::ConstructUFunction(&ReturnFunction, Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics
	{
		struct Cpp_AdvancedFunctionLibrary_eventGetRelativeSize_Parms
		{
			const UStaticMeshComponent* Target;
			FVector RelativeSize;
		};
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_Target_MetaData[];
#endif
		static const UECodeGen_Private::FObjectPropertyParams NewProp_Target;
		static const UECodeGen_Private::FStructPropertyParams NewProp_RelativeSize;
		static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UECodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::NewProp_Target_MetaData[] = {
		{ "EditInline", "true" },
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FObjectPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::NewProp_Target = { "Target", nullptr, (EPropertyFlags)0x0010000000080082, UECodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetRelativeSize_Parms, Target), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::NewProp_Target_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::NewProp_Target_MetaData)) };
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::NewProp_RelativeSize = { "RelativeSize", nullptr, (EPropertyFlags)0x0010000000000180, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventGetRelativeSize_Parms, RelativeSize), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(nullptr, 0) };
	const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::PropPointers[] = {
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::NewProp_Target,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::NewProp_RelativeSize,
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::Function_MetaDataParams[] = {
		{ "Category", "Components|Static Mesh" },
		{ "Comment", "//Returns FVector local static mesh dimensions, independent of world placement\n" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
		{ "ToolTip", "Returns FVector local static mesh dimensions, independent of world placement" },
	};
#endif
	const UECodeGen_Private::FFunctionParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, nullptr, "GetRelativeSize", nullptr, nullptr, sizeof(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::Cpp_AdvancedFunctionLibrary_eventGetRelativeSize_Parms), Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::PropPointers), RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04C42401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UECodeGen_Private::ConstructUFunction(&ReturnFunction, Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics
	{
		struct Cpp_AdvancedFunctionLibrary_eventSetHitDegreeChangeXY_Parms
		{
			const AActor* Target;
			const UStaticMeshComponent* StaticMesh;
			FVector HitNormal;
			FVector RelativeHitLocation;
			FVector NewTargetVector;
			float DegreeChangeRatio;
		};
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_Target_MetaData[];
#endif
		static const UECodeGen_Private::FObjectPropertyParams NewProp_Target;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_StaticMesh_MetaData[];
#endif
		static const UECodeGen_Private::FObjectPropertyParams NewProp_StaticMesh;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_HitNormal_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_HitNormal;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_RelativeHitLocation_MetaData[];
#endif
		static const UECodeGen_Private::FStructPropertyParams NewProp_RelativeHitLocation;
		static const UECodeGen_Private::FStructPropertyParams NewProp_NewTargetVector;
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam NewProp_DegreeChangeRatio_MetaData[];
#endif
		static const UECodeGen_Private::FFloatPropertyParams NewProp_DegreeChangeRatio;
		static const UECodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UECodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_Target_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FObjectPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_Target = { "Target", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventSetHitDegreeChangeXY_Parms, Target), Z_Construct_UClass_AActor_NoRegister, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_Target_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_Target_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_StaticMesh_MetaData[] = {
		{ "EditInline", "true" },
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FObjectPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_StaticMesh = { "StaticMesh", nullptr, (EPropertyFlags)0x0010000000080082, UECodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventSetHitDegreeChangeXY_Parms, StaticMesh), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_StaticMesh_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_StaticMesh_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_HitNormal_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_HitNormal = { "HitNormal", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventSetHitDegreeChangeXY_Parms, HitNormal), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_HitNormal_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_HitNormal_MetaData)) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_RelativeHitLocation_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_RelativeHitLocation = { "RelativeHitLocation", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventSetHitDegreeChangeXY_Parms, RelativeHitLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_RelativeHitLocation_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_RelativeHitLocation_MetaData)) };
	const UECodeGen_Private::FStructPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_NewTargetVector = { "NewTargetVector", nullptr, (EPropertyFlags)0x0010000000000180, UECodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventSetHitDegreeChangeXY_Parms, NewTargetVector), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(nullptr, 0) };
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_DegreeChangeRatio_MetaData[] = {
		{ "NativeConst", "" },
	};
#endif
	const UECodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_DegreeChangeRatio = { "DegreeChangeRatio", nullptr, (EPropertyFlags)0x0010000000000082, UECodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, nullptr, nullptr, STRUCT_OFFSET(Cpp_AdvancedFunctionLibrary_eventSetHitDegreeChangeXY_Parms, DegreeChangeRatio), METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_DegreeChangeRatio_MetaData, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_DegreeChangeRatio_MetaData)) };
	const UECodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::PropPointers[] = {
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_Target,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_StaticMesh,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_HitNormal,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_RelativeHitLocation,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_NewTargetVector,
		(const UECodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::NewProp_DegreeChangeRatio,
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::Function_MetaDataParams[] = {
		{ "Category", "Physics|Constraints" },
		{ "Comment", "//Returns identical vector magnitude, but changes a hit object's bounce angle depending on hit location relative to both the normal vector of impact, and the impact object's bounds\n" },
		{ "CPP_Default_DegreeChangeRatio", "20.000000" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
		{ "ToolTip", "Returns identical vector magnitude, but changes a hit object's bounce angle depending on hit location relative to both the normal vector of impact, and the impact object's bounds" },
	};
#endif
	const UECodeGen_Private::FFunctionParams Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, nullptr, "SetHitDegreeChangeXY", nullptr, nullptr, sizeof(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::Cpp_AdvancedFunctionLibrary_eventSetHitDegreeChangeXY_Parms), Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::PropPointers), RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04C42401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UECodeGen_Private::ConstructUFunction(&ReturnFunction, Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	IMPLEMENT_CLASS_NO_AUTO_REGISTRATION(UCpp_AdvancedFunctionLibrary);
	UClass* Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_NoRegister()
	{
		return UCpp_AdvancedFunctionLibrary::StaticClass();
	}
	struct Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics
	{
		static UObject* (*const DependentSingletons[])();
		static const FClassFunctionLinkInfo FuncInfo[];
#if WITH_METADATA
		static const UECodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UECodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_UBlueprintFunctionLibrary,
		(UObject* (*)())Z_Construct_UPackage__Script_Pong,
	};
	const FClassFunctionLinkInfo Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics::FuncInfo[] = {
		{ &Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetActorRelativeHitLocation, "GetActorRelativeHitLocation" }, // 2501083156
		{ &Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetAngleBetweenVectors, "GetAngleBetweenVectors" }, // 1251826492
		{ &Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioX, "GetHitLocationRatioX" }, // 796652161
		{ &Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioXY, "GetHitLocationRatioXY" }, // 923104535
		{ &Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetHitLocationRatioY, "GetHitLocationRatioY" }, // 874719153
		{ &Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeHitLocation, "GetRelativeHitLocation" }, // 2152820108
		{ &Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_GetRelativeSize, "GetRelativeSize" }, // 1941174591
		{ &Z_Construct_UFunction_UCpp_AdvancedFunctionLibrary_SetHitDegreeChangeXY, "SetHitDegreeChangeXY" }, // 1409699379
	};
#if WITH_METADATA
	const UECodeGen_Private::FMetaDataPairParam Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "Comment", "/**\n * \n */" },
		{ "IncludePath", "Cpp_AdvancedFunctionLibrary.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Public/Cpp_AdvancedFunctionLibrary.h" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<UCpp_AdvancedFunctionLibrary>::IsAbstract,
	};
	const UECodeGen_Private::FClassParams Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics::ClassParams = {
		&UCpp_AdvancedFunctionLibrary::StaticClass,
		nullptr,
		&StaticCppClassTypeInfo,
		DependentSingletons,
		FuncInfo,
		nullptr,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		UE_ARRAY_COUNT(FuncInfo),
		0,
		0,
		0x001000A0u,
		METADATA_PARAMS(Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_UCpp_AdvancedFunctionLibrary()
	{
		if (!Z_Registration_Info_UClass_UCpp_AdvancedFunctionLibrary.OuterSingleton)
		{
			UECodeGen_Private::ConstructUClass(Z_Registration_Info_UClass_UCpp_AdvancedFunctionLibrary.OuterSingleton, Z_Construct_UClass_UCpp_AdvancedFunctionLibrary_Statics::ClassParams);
		}
		return Z_Registration_Info_UClass_UCpp_AdvancedFunctionLibrary.OuterSingleton;
	}
	template<> PONG_API UClass* StaticClass<UCpp_AdvancedFunctionLibrary>()
	{
		return UCpp_AdvancedFunctionLibrary::StaticClass();
	}
	DEFINE_VTABLE_PTR_HELPER_CTOR(UCpp_AdvancedFunctionLibrary);
	UCpp_AdvancedFunctionLibrary::~UCpp_AdvancedFunctionLibrary() {}
	struct Z_CompiledInDeferFile_FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_Statics
	{
		static const FClassRegisterCompiledInInfo ClassInfo[];
	};
	const FClassRegisterCompiledInInfo Z_CompiledInDeferFile_FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_Statics::ClassInfo[] = {
		{ Z_Construct_UClass_UCpp_AdvancedFunctionLibrary, UCpp_AdvancedFunctionLibrary::StaticClass, TEXT("UCpp_AdvancedFunctionLibrary"), &Z_Registration_Info_UClass_UCpp_AdvancedFunctionLibrary, CONSTRUCT_RELOAD_VERSION_INFO(FClassReloadVersionInfo, sizeof(UCpp_AdvancedFunctionLibrary), 2241318073U) },
	};
	static FRegisterCompiledInInfo Z_CompiledInDeferFile_FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_2279975194(TEXT("/Script/Pong"),
		Z_CompiledInDeferFile_FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_Statics::ClassInfo, UE_ARRAY_COUNT(Z_CompiledInDeferFile_FID_Pong_NathanielWeissinger_v10_5_1_Source_Pong_Public_Cpp_AdvancedFunctionLibrary_h_Statics::ClassInfo),
		nullptr, 0,
		nullptr, 0);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
