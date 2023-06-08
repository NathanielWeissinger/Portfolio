// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Kismet/KismetMathLibrary.h"
#include "Math/Vector.h"
#include "Cpp_AdvancedFunctionLibrary.generated.h"

/**
 * 
 */
UCLASS(Blueprintable, BlueprintType)
class PONG_API UCpp_AdvancedFunctionLibrary : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()

	//Returns FVector hit location relative to object origin
	UFUNCTION(BlueprintCallable, Category = "Math|Vector")
		static void GetRelativeHitLocation( const FVector WorldHitLocation, const FVector WorldOriginLocation, FVector& RelativeHitLocation );

	//Returns FVector hit location relative to object origin
	UFUNCTION( BlueprintCallable, Category = "Math|Vector" )
		static void GetActorRelativeHitLocation( const FVector WorldHitLocation, const USceneComponent* Target, FVector& RelativeHitLocation );

	//Returns float of angle in degrees between two vectors in 3D space
	UFUNCTION( BlueprintCallable, Category = "Math|Vector" )
		static void GetAngleBetweenVectors( const FVector Vector1, const FVector Vector2, float& Angle );

	//Returns FVector local static mesh dimensions, independent of world placement
	UFUNCTION( BlueprintCallable, Category = "Components|Static Mesh" )
		static void GetRelativeSize( const UStaticMeshComponent* Target, FVector& RelativeSize );

	//Returns value between 1 and -1 of X-axis hit location on XY plane
	UFUNCTION( BlueprintCallable, Category = "Physics|Constraints" )
		static void GetHitLocationRatioX( const USceneComponent* Target, const FVector RelativeHitLocation, float& HLRX );

	//Returns value between 1 and -1 of Y-axis hit location on XY plane
	UFUNCTION( BlueprintCallable, Category = "Physics|Constraints" )
		static void GetHitLocationRatioY( const USceneComponent* Target, const FVector RelativeHitLocation, float& HLRY );

	//Returns value between 1 and -1 of 2D hit location on XY plane
	UFUNCTION( BlueprintCallable, Category = "Physics|Constraints" )
		static void GetHitLocationRatioXY( const USceneComponent* Target, const FVector RelativeHitLocation, float& HLR );

	//Returns identical vector magnitude, but changes a hit object's bounce angle depending on hit location relative to both the normal vector of impact, and the impact object's bounds
	UFUNCTION( BlueprintCallable, Category = "Physics|Constraints" )
		static void SetHitDegreeChangeXY( const AActor* Target, const UStaticMeshComponent* StaticMesh, const FVector HitNormal, const FVector RelativeHitLocation, FVector& NewTargetVector, const float DegreeChangeRatio = 20.f );
};
