using ObjCRuntime;

[assembly: LinkWith ("libPayPalOneTouchCore.a", LinkTarget.Simulator 
	| LinkTarget.Simulator64 
	| LinkTarget.Arm64
	| LinkTarget.ArmV7, 
	ForceLoad = true,
	IsCxx = true)]
