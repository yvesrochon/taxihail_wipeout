﻿using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security;

[assembly: AssemblyTitle("System.Reactive.PlatformServices")]
// Notice: same description as in the .nuspec files; see Source/Rx/Setup/NuGet
[assembly: AssemblyDescription("Reactive Extensions Platform Services Library used to access platform-specific functionality and enlightenment services.")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Retail")]
#endif
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("Reactive Extensions")]
[assembly: AssemblyCopyright("\x00a9 Microsoft Corporation.  All rights reserved.")]
[assembly: NeutralResourcesLanguage("en-US")]

#if !PLIB
[assembly: ComVisible(false)]
#endif

[assembly: CLSCompliant(true)]

#if HAS_APTCA && NO_CODECOVERAGE
[assembly: AllowPartiallyTrustedCallers]
#endif

#if XBOX_LAKEVIEW
[assembly: SecurityTransparent]
#endif

//
// Note: Assembly (file) version numbers get inserted by the build system on the fly. Inspect the Team Build workflows
//       and the custom activity in Build/Source/Activities/AppendVersionInfo.cs for more information.
//
