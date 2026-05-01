# .NET 10.0 Upgrade Plan

**Project**: Inventory System DBSP  
**Current Framework**: .NET Framework 4.7.2  
**Target Framework**: .NET 10.0 (LTS)  
**Strategy**: All-At-Once  
**Date**: 2024

---

## Executive Summary

Upgrade the Inventory System DBSP Windows Forms application from .NET Framework 4.7.2 to .NET 10.0. This is a single-project, straightforward upgrade with well-understood migration paths for Windows Forms and System.Drawing APIs.

### Scope
- **Total Projects**: 1 (Inventory System DBSP)
- **Project Type**: Windows Forms (ClassicWinForms)
- **Current Project Format**: Legacy .csproj (non-SDK-style)
- **Total Code Files**: 10
- **Estimated LOC to Modify**: 690+ (71.9% of codebase)

### Key Challenges
1. **Windows Forms Modernization**: 549 API issues (79.6%) — Windows Forms fully supported but requires target framework adjustment
2. **GDI+ / System.Drawing**: 106 API issues (15.4%) — NuGet package required
3. **Windows Forms Legacy Controls**: 58 API issues (8.4%) — StatusBar, DataGrid, ContextMenu, MainMenu, MenuItem, ToolBar removed; replacements needed (ToolStrip, MenuStrip, ContextMenuStrip, DataGridView)
4. **System.Data.SqlClient Migration**: System.Data.SqlClient → Microsoft.Data.SqlClient
5. **Legacy Configuration**: app.config → Microsoft.Extensions.Configuration pattern (8 issues)
6. **Package Compatibility**: MaterialSkin.2 v2.3.1 (1 incompatible package)

### Success Criteria
- [ ] Project converted to SDK-style format
- [ ] Target framework updated to .NET 10.0
- [ ] All dependencies resolved (including Windows Desktop SDK)
- [ ] Solution builds with 0 errors
- [ ] No compiler warnings related to deprecated APIs
- [ ] All tests pass (if applicable)

---

## Selected Strategy

### All-At-Once
**All projects upgraded simultaneously in a single operation.**

**Rationale**:
- Single project with no inter-project dependencies
- Straightforward upgrade: Windows Forms is fully supported in .NET 10.0
- Well-understood migration paths for all identified API issues
- No phasing or dependency ordering required
- Single atomic upgrade provides clarity and simplicity

---

## Tasks

### Task 01: Project Modernization & Infrastructure
**Objective**: Convert project to SDK-style format and prepare for .NET 10.0

**Scope**:
- Convert legacy .csproj to SDK-style format (preserves all current configuration)
- Verify/validate global.json compatibility (if exists)
- Document pre-upgrade state

**Success Criteria**:
- Project file converted to SDK-style
- Project still builds (before TFM change)
- No build warnings introduced by conversion

**Estimated Effort**: Low (automated conversion + validation)

---

### Task 02: Target Framework & Package Update
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

---

### Task 03: API Breaking Changes & Code Fixes
**Objective**: Fix all source/binary incompatibilities and deprecated API usage

**Scope**:
- **Windows Forms API fixes**: Update bindings for Label, Panel, Button, Control collections (44+21+14 instances)
- **System.Drawing fixes**: Update Font, GraphicsUnit, Image usage (GDI+ NuGet provides these)
- **Legacy Controls replacement**: 
  - StatusBar → StatusStrip
  - ContextMenu → ContextMenuStrip
  - MainMenu / MenuItem → MenuStrip
  - DataGrid → DataGridView (if used)
- **System.Data.SqlClient → Microsoft.Data.SqlClient**: Update DatabaseHelper.cs, connection strings
- **Configuration Migration** (Optional - can defer to Phase 2):
  - Document app.config → appsettings.json migration approach
  - If urgent: migrate 8 affected configuration calls

**Success Criteria**:
- Solution compiles with 0 errors
- No CS0246 (missing type/namespace) errors
- No deprecated API warnings
- All Windows Forms features functional

**Estimated Effort**: Medium (690+ LOC changes, mostly mechanical)

---

### Task 04: Testing & Validation
**Objective**: Verify functionality and catch runtime issues

**Scope**:
- Build solution in Release configuration
- Run all unit tests (if applicable)
- Manual smoke test: UI loads, login flow works, basic DB operations (select, insert, update)
- Verify no P/Invoke or unsafe code breaks due to Windows Desktop context

**Success Criteria**:
- Release build succeeds
- All tests pass
- Login screen renders correctly
- Database operations functional
- No runtime exceptions in critical paths

**Estimated Effort**: Low-Medium (depends on test coverage)

---

## Timeline Estimate

| Task | Effort | Duration |
|------|--------|----------|
| 01: Project Modernization | Low | 30 min |
| 02: Framework & Packages | Low-Medium | 1-2 hours |
| 03: API Fixes & Code Changes | Medium | 2-4 hours |
| 04: Testing & Validation | Low-Medium | 1-2 hours |
| **Total** | **Medium** | **4-9 hours** |

---

## Risks & Mitigation

| Risk | Likelihood | Impact | Mitigation |
|------|-----------|--------|-----------|
| MaterialSkin incompatibility | High | Blocking (no compatible version found) | Research alternatives (ModernUILibrary, MetroFramework) or pin package version with polyfills |
| Windows Desktop SDK not installed | Medium | Build failure | Validate .NET 10.0 SDK + Windows Desktop support before starting |
| Third-party dependencies on .NET 4.7.2 | Medium | Integration issues | Audit all NuGet packages for .NET 10.0 support in Task 02 |
| UI rendering differences | Low | Cosmetic issues | Manual testing phase will catch |
| Database connection failures | Low | Runtime error | Microsoft.Data.SqlClient compatibility with existing connection strings |

---

## Next Steps

1. **Review this plan** and confirm strategy choice
2. **Proceed to Execution** — tasks execute in order
3. **Each task generates detailed progress logs** in execution-log.md
4. **Commit per-task** (recommended: commit after Tasks 02, 03, 04 complete)

---

## Appendix: Assessment References

Full assessment data available in `assessment.md`:
- Complete API compatibility matrix
- Per-project breaking changes
- NuGet package recommendations
- Code file analysis (9 of 10 files have incidents)

---
