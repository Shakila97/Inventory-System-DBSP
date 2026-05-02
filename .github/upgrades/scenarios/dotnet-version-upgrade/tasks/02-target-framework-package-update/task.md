# 02-target-framework-package-update: Target Framework & Package Update

**Objective**: Update target framework to .NET 10.0 and resolve NuGet dependencies

**Scope**:
- Change TargetFramework from `net472` to `net10.0-windows` (Windows Desktop support)
- Update package references from packages.config to PackageReference format
- Identify compatible versions for:
  - MaterialSkin (currently 2.3.1 — incompatible with .NET 10.0)
  - System.Drawing.Common (for GDI+ support)
  - Microsoft.Data.SqlClient (replace System.Data.SqlClient)
- Run NuGet restore and resolve dependency conflicts

**Success Criteria**:
- All packages resolved to compatible versions
- No NuGet warnings or conflicts
- Solution compiles to exe (before code fixes)

**Estimated Effort**: Low-Medium (package research + compatibility verification)

