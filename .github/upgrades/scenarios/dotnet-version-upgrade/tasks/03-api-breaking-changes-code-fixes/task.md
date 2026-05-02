# 03-api-breaking-changes-code-fixes: API Breaking Changes & Code Fixes

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

