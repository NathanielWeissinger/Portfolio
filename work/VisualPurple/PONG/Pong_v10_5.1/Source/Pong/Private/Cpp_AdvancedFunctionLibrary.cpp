// Fill out your copyright notice in the Description page of Project Settings.


#include "Cpp_AdvancedFunctionLibrary.h"

void UCpp_AdvancedFunctionLibrary::GetRelativeHitLocation( const FVector WorldHitLocation, const FVector WorldOriginLocation, FVector& RelativeHitLocation )
{
	RelativeHitLocation = FVector( WorldHitLocation.X - WorldOriginLocation.X, WorldHitLocation.Y - WorldOriginLocation.Y, WorldHitLocation.Z - WorldOriginLocation.Z );
}

void UCpp_AdvancedFunctionLibrary::GetActorRelativeHitLocation( const FVector WorldHitLocation, const USceneComponent* Target, FVector& RelativeHitLocation )
{
	FVector WorldOriginLocation = Target->GetComponentLocation();
	RelativeHitLocation = FVector( WorldHitLocation.X - WorldOriginLocation.X, WorldHitLocation.Y - WorldOriginLocation.Y, WorldHitLocation.Z - WorldOriginLocation.Z);
}

void UCpp_AdvancedFunctionLibrary::GetAngleBetweenVectors( const FVector Vector1, const FVector Vector2, float& Angle )
{
	float DotProduct = (float) FVector::DotProduct( Vector1, Vector2 );
	float Mag1 = sqrt( pow( Vector1.X, 2 ) + pow( Vector1.Y, 2 ) + pow( Vector1.Z, 2 ) );
	float Mag2 = sqrt( pow( Vector2.X, 2 ) + pow( Vector2.Y, 2 ) + pow( Vector2.Z, 2 ) );
	Angle = 180 - ( acos( DotProduct / ( Mag1 * Mag2 ) ) * 180 / PI );
}

void UCpp_AdvancedFunctionLibrary::GetRelativeSize( const UStaticMeshComponent* Target, FVector& RelativeSize )
{
	FVector RelativeScale3D = Target->GetRelativeScale3D();
	FBoxSphereBounds MeshBounds = Target->GetStaticMesh()->GetBounds();
	FVector Min = MeshBounds.Origin - MeshBounds.BoxExtent;
	FVector Max = MeshBounds.Origin + MeshBounds.BoxExtent;
	FVector Size = ( Max - Min ) / 2;
    RelativeSize = RelativeScale3D * Size;
}

void UCpp_AdvancedFunctionLibrary::GetHitLocationRatioX( const USceneComponent* Target, const FVector RelativeHitLocation, float& HLRX )
{
	FVector componentSize;
	GetRelativeSize( Cast<UStaticMeshComponent>( Target ), componentSize );

	float vectorLengthSq = pow( RelativeHitLocation.X, 2 ) + pow( RelativeHitLocation.Y, 2 ) + pow( RelativeHitLocation.Z, 2 );
	float vectorBoxExtentX = sqrt( vectorLengthSq - pow( componentSize.Y, 2 ) ) / componentSize.X;

	if (RelativeHitLocation.X <= 0)
		HLRX = vectorBoxExtentX;
	else
		HLRX = vectorBoxExtentX * -1;
}

void UCpp_AdvancedFunctionLibrary::GetHitLocationRatioY( const USceneComponent* Target, const FVector RelativeHitLocation, float& HLRY )
{
	FVector componentSize;
	GetRelativeSize( Cast<UStaticMeshComponent>( Target ), componentSize );

	float vectorLengthSq = pow( RelativeHitLocation.X, 2 ) + pow( RelativeHitLocation.Y, 2 ) + pow( RelativeHitLocation.Z, 2 );
	float vectorBoxExtentY = sqrt( vectorLengthSq - pow( componentSize.X, 2 ) ) / componentSize.Y;

	if (RelativeHitLocation.Y <= 0)
	{
		HLRY = vectorBoxExtentY;
	}
	else
	{
		HLRY = vectorBoxExtentY * -1;
	}
}

void UCpp_AdvancedFunctionLibrary::GetHitLocationRatioXY( const USceneComponent* Target, const FVector RelativeHitLocation, float& HLR)
{
	FVector componentSize;
	GetRelativeSize( Cast<UStaticMeshComponent>( Target ), componentSize );
	FRotator SelfRotator = Target->K2_GetComponentRotation();
	FVector rotation = FVector( SelfRotator.Roll, SelfRotator.Pitch, SelfRotator.Yaw );

	//Distance to hit point on XY plane
	float vectorLengthSq = pow( RelativeHitLocation.X, 2 ) + pow( RelativeHitLocation.Y, 2 );

	//Subtracts out Y width of component to get local X distance from origin
	//float distanceX = sqrt( vectorLengthSq - pow( componentSize.Y, 2 ) ) * cos( rotation.Z * PI/180 );
	//float distanceY = sqrt( vectorLengthSq - pow( componentSize.Y, 2 ) ) * sin( rotation.Z * PI/180 );

	float side = 0;
	if (((int) rotation.Z % 180 >= 45) && ((int) rotation.Z % 180 < 135)) //Between 45 and 135
	{
		if (RelativeHitLocation.Y <= 0)
			side = -1;
		else
			side = 1;
		//GEngine->AddOnScreenDebugMessage( -1, 15.0f, FColor::Yellow, FString::Printf( TEXT( "45-135, %f" ), side ) );
	}
	else //Between 135 and 180, or between 0 and 45
	{
		if (RelativeHitLocation.X <= 0)
			side = -1;
		else
			side = 1;
		//GEngine->AddOnScreenDebugMessage( -1, 15.0f, FColor::Yellow, FString::Printf( TEXT( "0-45, 135-180, %f" ), side ) );
	}

	//Divides out the X width to give 0-1 ratio of where the hit was located
	HLR = side * sqrt( vectorLengthSq - pow( componentSize.Y, 2 ) ) / componentSize.X;
}

void UCpp_AdvancedFunctionLibrary::SetHitDegreeChangeXY( const AActor* Target, const UStaticMeshComponent* StaticMesh, const FVector HitNormal, const FVector RelativeHitLocation, FVector& NewTargetVector, const float DegreeChangeRatio )
{
	//ANGLE CHANGE IS WRONG, angle is always positive currently. Needs direction to determine if angle is going away from normal.

	//Gets rotation of self static mesh component (paddle)
	FVector componentSize;
	GetRelativeSize( Cast<UStaticMeshComponent>( StaticMesh ), componentSize );
	FRotator SelfRotator = StaticMesh->K2_GetComponentRotation();
	FVector rotation = FVector( SelfRotator.Roll, SelfRotator.Pitch, SelfRotator.Yaw );

	//Gets ball velocity
	FVector TargetVelocity = Target->GetVelocity();
	float TargetVectorLength = UKismetMathLibrary::VSize( TargetVelocity );
	//FVector TargetReflection = UKismetMathLibrary::GetReflectionVector( TargetVelocity, HitNormal );
	FVector NormalizedTargetVelocity = UKismetMathLibrary::Normal( TargetVelocity, 0.0001f );

	//Distance to hit point on XY plane
	float vectorLengthSq = pow( RelativeHitLocation.X, 2 ) + pow( RelativeHitLocation.Y, 2 );


	/*float side = 0;
	if (((int)rotation.Z % 180 >= 45) && ((int)rotation.Z % 180 < 135)) //Between 45 and 135
	{
		if (RelativeHitLocation.Y <= 0)
			side = -1;
		else
			side = 1;
		//GEngine->AddOnScreenDebugMessage( -1, 15.0f, FColor::Yellow, FString::Printf( TEXT( "45-135, %f" ), side ) );
	}
	else //Between 135 and 180, or between 0 and 45
	{
		if (RelativeHitLocation.X <= 0)
			side = -1;
		else
			side = 1;
		//GEngine->AddOnScreenDebugMessage( -1, 15.0f, FColor::Yellow, FString::Printf( TEXT( "0-45, 135-180, %f" ), side ) );
	}*/

	//NOT CORRECT: Ball down, moving right, hits top left of paddle. Causes angle to increase in wrong direction.
	//NOT CORRECT: Ball up, moving right, hits bottom left of paddle. Causes angle to increase in wrong direction.
	float side = 0;
	if (((int)rotation.Z % 180 >= 45) && ((int)rotation.Z % 180 < 135)) //Between 45 and 135
	{
		if (RelativeHitLocation.Y <= 0 && TargetVelocity.Y <= 0) //Hits left of paddle, ball moving left
			side = -1;
		else if (RelativeHitLocation.Y <= 0 && TargetVelocity.Y > 0) //Hits left of paddle, ball moving right
			side = 1;
		else if (RelativeHitLocation.Y > 0 && TargetVelocity.Y <= 0) //Hits right of paddle, ball moving right
			side = 1;
		else if (RelativeHitLocation.Y > 0 && TargetVelocity.Y > 0) //Hits right of paddle, ball moving left
			side = -1;
		//GEngine->AddOnScreenDebugMessage( -1, 15.0f, FColor::Yellow, FString::Printf( TEXT( "45-135, %f" ), side ) );
	}
	//NOT CORRECT: Ball down, moving left, hits bottom right of paddle. Causes angle to increase in wrong direction.
	else //Between 135 and 180, or between 0 and 45
	{
		if (RelativeHitLocation.X <= 0 && TargetVelocity.X <= 0) //Hits bottom of paddle, ball moving down
			side = 1;
		else if (RelativeHitLocation.X <= 0 && TargetVelocity.X > 0) //Hits bottom of paddle, ball moving up
			side = -1;
		else if (RelativeHitLocation.X > 0 && TargetVelocity.X <= 0) //Hits top of paddle, ball moving down
			side = -1;
		else if (RelativeHitLocation.X > 0 && TargetVelocity.X > 0) //Hits top of paddle, ball moving up
			side = 1;
		//GEngine->AddOnScreenDebugMessage( -1, 15.0f, FColor::Yellow, FString::Printf( TEXT( "0-45, 135-180, %f" ), side ) );
	}

	//Divides out the X width to give 0-1 ratio of where the hit was located
	float HLR = sqrt( vectorLengthSq - pow( componentSize.Y, 2 ) ) / componentSize.X;

	//Hit Angle relative to normal vector of surface hit and ball velocity
	float HitAngle;
	GetAngleBetweenVectors( NormalizedTargetVelocity, HitNormal, HitAngle );

	//Changes hit angle based on DegreeChangeRatio
	float NewHitAngle;
	NewHitAngle = tan( (HitAngle + (side * HLR * DegreeChangeRatio)) * PI / 180 );

	
	float NewNormalTargetVectorY = sqrt( 1 / ( pow( NewHitAngle, 2 ) + 1 ) );
	float NewNormalTargetVectorX = NewHitAngle * NewNormalTargetVectorY;

	if (TargetVelocity.Y <= 0)
		NewNormalTargetVectorY = -1 * NewNormalTargetVectorY;
	if (TargetVelocity.X <= 0)
		NewNormalTargetVectorX = -1 * NewNormalTargetVectorX;

	if(HLR >= -0.98  &&  HLR <= 0.98)
		NewTargetVector = FVector(TargetVectorLength * NewNormalTargetVectorX, TargetVectorLength * NewNormalTargetVectorY, 0);
	else
		NewTargetVector = TargetVelocity;
}