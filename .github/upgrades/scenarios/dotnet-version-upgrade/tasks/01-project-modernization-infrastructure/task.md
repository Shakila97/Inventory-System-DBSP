# 01-project-modernization-infrastructure: Project Modernization & Infrastructure

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

