# Scenario Instructions

**Scenario**: dotnet-version-upgrade  
**Project**: Inventory System DBSP  
**Target Framework**: .NET 10.0 (LTS)  
**Date Started**: 2024

---

## Strategy

**Selected**: All-At-Once  
**Rationale**: Single project with no inter-project dependencies, straightforward Windows Forms upgrade, well-understood migration paths for all identified API issues.

### Execution Constraints
- All projects upgraded simultaneously in single atomic operation
- No tier ordering or phasing required
- Single bounded compilation/fix pass after package updates
- Validate full solution build after all code changes
- Commit strategy: **After Each Task** (allows per-task validation and rollback capability)

---

## Workflow Progress

**Current Stage**: Planning (COMPLETE)  
**Next Stage**: Execution

**Stages**:
- [x] Pre-Initialization (Branch: upgrade-to-NET10, Source: Dev-Shakila)
- [x] Assessment (Complete — 693 issues identified, 1 project, 690+ LOC impact)
- [x] Planning (Complete — 4 tasks defined)
- [ ] Execution (Ready to start)

---

## Preferences

### Flow Mode
**Mode**: Automatic  
**Description**: Run end-to-end, surface assessments and plans, pause only when blocked or requiring user decision.

### Technical Preferences
- **Target Framework**: .NET 10.0 (LTS)
- **Project Format**: SDK-style (converted from legacy)
- **Windows Desktop Support**: `net10.0-windows` target framework suffix
- **Commit Strategy**: After Each Task

### Source Control
- **Source Branch**: Dev-Shakila
- **Working Branch**: upgrade-to-NET10
- **Pending Changes**: Committed (commit: 42d3ad3)

---

## Key Decisions Log

| Date | Decision | Rationale |
|------|----------|-----------|
| 2024 | Strategy: All-At-Once | Single project, straightforward Windows Forms upgrade, no dependency ordering needed |
| 2024 | Target: .NET 10.0 (LTS) | Latest stable LTS, full Windows Forms support, long-term support commitment |
| 2024 | Commit After Each Task | Enables per-task validation and rollback capability in single-project workflow |

---

## Tasks Overview

| ID | Task | Status | Effort |
|----|------|--------|--------|
| 01 | Project Modernization & Infrastructure | Ready | Low |
| 02 | Target Framework & Package Update | Ready | Low-Medium |
| 03 | API Breaking Changes & Code Fixes | Ready | Medium |
| 04 | Testing & Validation | Ready | Low-Medium |

---

## Risks

| Risk | Likelihood | Impact | Mitigation |
|------|-----------|--------|-----------|
| MaterialSkin incompatibility | High | Blocking | Research alternatives or pin version with polyfills |
| Windows Desktop SDK not installed | Medium | Build failure | Validate SDK before starting Task 01 |
| Third-party dependencies | Medium | Integration issues | Audit NuGet packages in Task 02 |

---

## Notes

- Assessment identified 549 Windows Forms API issues (79.6%) — all resolvable with proper target framework + NuGet packages
- GDI+ support requires System.Drawing.Common NuGet (15.4% of issues)
- Legacy controls (StatusBar, ContextMenu, etc.) have direct replacements
- Database migration: System.Data.SqlClient → Microsoft.Data.SqlClient
- Configuration: Can defer app.config → appsettings.json migration if not urgent (8 issues)

---
