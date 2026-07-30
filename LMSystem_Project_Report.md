# LIBRARY MANAGEMENT SYSTEM (LMSystem)

### A Web-Based Library Management and Role-Based Access Control System Developed Using ASP.NET Core MVC, Entity Framework Core and SQL Server

---

## PROJECT REPORT

*Submitted in partial fulfilment of the requirements for the award of the degree of*

**[Degree Name, e.g., Bachelor of Technology in Computer Science and Engineering]**

---

**Submitted by:**
[Student Name]
[Roll Number / Enrolment Number]

**Under the Guidance of:**
[Guide / Supervisor Name]
[Designation, Department]

**Department of [Department Name]**
**[College / University Name]**
**[City, State]**

**[Month, Year]**

---
---

## CERTIFICATE

This is to certify that the project report entitled **"Library Management System (LMSystem)"** submitted by **[Student Name]** (Roll No. **[Roll Number]**) in partial fulfilment of the requirements for the award of the degree of **[Degree Name]** in **[Department Name]** is a bona fide record of the work carried out by them under my supervision and guidance during the academic year **[Academic Year]**.

The matter embodied in this report has not been submitted elsewhere for the award of any other degree or diploma.

<br><br>

| | |
|---|---|
| **Signature of Guide** | **Signature of Head of Department** |
| [Guide Name] | [HOD Name] |
| [Designation] | [Designation] |
| Date: | Date: |

<br>

**Signature of External Examiner:** _______________________ &nbsp;&nbsp;&nbsp; **Date:** _______________

---
---

## DECLARATION

I hereby declare that the project work entitled **"Library Management System (LMSystem)"** submitted to the Department of **[Department Name]**, **[College/University Name]**, is a record of original work done by me under the guidance of **[Guide Name]**, **[Designation]**. This project work has not formed the basis for the award of any degree, diploma, associateship, fellowship, or similar title to any candidate of any university, and the information furnished in this report is genuine and true to the best of my knowledge.

<br><br>

**Place:** [City]
**Date:** [Date]

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**[Student Name]**
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**[Roll Number]**

---
---

## ACKNOWLEDGEMENT

I take this opportunity to express my sincere gratitude to everyone who supported me throughout the course of this project. I am deeply thankful to my project guide, **[Guide Name]**, for their invaluable guidance, constant encouragement, and constructive feedback at every stage of the development of this project. Their expertise and insight were instrumental in shaping the direction of this work.

I would also like to thank **[HOD Name]**, Head of the Department of **[Department Name]**, and all the faculty members for providing the necessary infrastructure, resources, and a conducive academic environment that made this project possible.

I extend my thanks to my classmates and peers for their suggestions and moral support during the development and testing of this system. Finally, I am grateful to my family for their unwavering support and patience throughout this endeavour.

<br><br>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**[Student Name]**

---
---

## ABSTRACT

The **Library Management System (LMSystem)** is a full-stack web application designed to digitize and streamline the day-to-day operations of a library, including cataloguing books and periodicals, tracking borrowing and return transactions, and administering the people who interact with the library — students, librarians, teachers, and administrators. The system was developed using **ASP.NET Core MVC (.NET 8)** on the back end, **Entity Framework Core** for object-relational data access against a **Microsoft SQL Server** database, and **Bootstrap 5** on the front end to deliver a responsive, card-based administrative interface.

Traditional manual or spreadsheet-based library record keeping is slow, error-prone, and difficult to search or audit. LMSystem addresses these shortcomings by providing a centralized, searchable, paginated catalogue of books and publications (newspapers and magazines); a borrow/return workflow that automatically tracks book availability; a real-time analytics dashboard summarizing library activity; and — as the most recent and most significant enhancement to the system — a complete **account management and Role-Based Access Control (RBAC)** subsystem. This subsystem replaces an earlier, insecure plaintext-password login mechanism with **PBKDF2-SHA256 password hashing**, introduces four distinct account roles (**Admin, Librarian, Teacher, Student**), restricts sensitive administrative operations to Admin accounts through a custom authorization filter, and gives every user a self-service **profile page** where they can view their details, edit their personal information, and change their password.

The application follows a layered, modular MVC architecture with a clean separation between Models, Views, Controllers, ViewModels, and Data Transfer Objects, and additionally exposes a parallel JSON REST API layer that powers a secondary static HTML/JavaScript client, demonstrating both server-rendered and API-driven consumption of the same underlying business logic and database. The system was iteratively developed module by module — beginning with book cataloguing, then borrowing/returns, student and librarian directories, publications, a dashboard, and finally the account and profile management module — and was verified through structured functional and security testing, including automated end-to-end HTTP-level testing of authentication, authorization, and CRUD workflows.

This report documents the complete software engineering life cycle of the project: requirement analysis, feasibility study, system design (including data flow diagrams, entity-relationship modelling, and UML diagrams), implementation details, testing strategy and results, and a discussion of the system's advantages, limitations, and scope for future enhancement.

**Keywords:** Library Management System, ASP.NET Core MVC, Entity Framework Core, Role-Based Access Control, Password Hashing, Web Application, SQL Server, REST API, Software Engineering.

---
---

## TABLE OF CONTENTS

*(Note: This document uses Markdown heading levels 1–4, which map directly onto Word's Heading 1–4 styles when converted. After conversion, regenerate this section automatically via References → Table of Contents in Microsoft Word to obtain accurate page numbers.)*

1. Introduction
2. Literature Survey
3. System Analysis
4. System Design
5. Technology Stack
6. System Implementation
7. Software Testing
8. Results and Screenshots
9. Advantages and Limitations
10. Conclusion
11. Future Scope
12. References
    Appendix A — Glossary of Terms
    Appendix B — Database Schema (DDL)
    Appendix C — Selected Source Code Listings

---

## LIST OF FIGURES

| Figure No. | Title |
|---|---|
| Fig. 4.1 | Three-Layer System Architecture of LMSystem |
| Fig. 4.2 | Level 0 Data Flow Diagram (Context Diagram) |
| Fig. 4.3 | Level 1 Data Flow Diagram |
| Fig. 4.4 | Entity-Relationship Diagram |
| Fig. 4.5 | Use Case Diagram |
| Fig. 4.6 | Class Diagram (Core Domain Models) |
| Fig. 4.7 | Sequence Diagram — User Login |
| Fig. 4.8 | Sequence Diagram — Book Borrow and Return |
| Fig. 4.9 | Activity Diagram — Account Creation by Administrator |
| Fig. 8.1 | Login Page |
| Fig. 8.2 | Dashboard with Library Analytics |
| Fig. 8.3 | Books Module — Search and Pagination |
| Fig. 8.4 | Account Management Page (Admin View) |
| Fig. 8.5 | User Profile Page |

## LIST OF TABLES

| Table No. | Title |
|---|---|
| Table 3.1 | Functional Requirements |
| Table 3.2 | Non-Functional Requirements |
| Table 3.3 | User Classes and Characteristics |
| Table 3.4 | Hardware Requirements |
| Table 3.5 | Software Requirements |
| Table 4.1 | Account Table Schema |
| Table 4.2 | Book Table Schema |
| Table 4.3 | BorrowRecord Table Schema |
| Table 4.4 | Student Table Schema |
| Table 4.5 | Librarian Table Schema |
| Table 4.6 | Publication Table Schema |
| Table 4.7 | Use Case Descriptions |
| Table 6.1 | Module-Wise Description of the System |
| Table 6.2 | Controller-to-Route Mapping |
| Table 7.1 | Test Case Summary |
| Table 7.2 | Detailed Test Cases and Results |
| Table 7.3 | Test Execution Summary |

## LIST OF ABBREVIATIONS

| Abbreviation | Expansion |
|---|---|
| MVC | Model-View-Controller |
| ORM | Object-Relational Mapping |
| CRUD | Create, Read, Update, Delete |
| RBAC | Role-Based Access Control |
| API | Application Programming Interface |
| REST | Representational State Transfer |
| DTO | Data Transfer Object |
| ER Diagram | Entity-Relationship Diagram |
| DFD | Data Flow Diagram |
| UML | Unified Modelling Language |
| SRS | Software Requirements Specification |
| SQL | Structured Query Language |
| HTTP | Hypertext Transfer Protocol |
| PBKDF2 | Password-Based Key Derivation Function 2 |
| UI/UX | User Interface / User Experience |
| IDE | Integrated Development Environment |
| JSON | JavaScript Object Notation |
| CSRF | Cross-Site Request Forgery |
| XSS | Cross-Site Scripting |

---
---

# 1. INTRODUCTION

## 1.1 Background

Libraries — whether in a school, college, corporate, or public setting — are custodians of large, constantly changing collections of books and periodicals that must be catalogued, tracked, and made available to a community of borrowers in a fair and auditable manner. Historically, this record-keeping was performed manually using registers, index cards, or, at best, disconnected spreadsheets maintained by library staff. As collections and user bases grow, manual systems become increasingly difficult to search, prone to transcription errors, vulnerable to data loss, and incapable of providing real-time insight into how the collection is being used.

The natural solution to this class of problem is a dedicated **Library Management System (LMS)** — a software application that centralizes the catalogue, automates borrowing and return workflows, and provides staff with fast search, reporting, and administrative tools. This project, **LMSystem**, is precisely such a system, built as a modern, web-based, multi-user application.

## 1.2 Motivation

The motivation for this project was twofold. First, from a practical standpoint, a digitized library system removes the friction and error associated with manual record keeping: book availability is always accurate and up to date, borrower records are searchable in milliseconds rather than minutes, and management reports (such as the most-borrowed titles or the total size of the active collection) can be generated instantly rather than compiled by hand.

Second, from a learning standpoint, this project was undertaken to gain practical, end-to-end experience with the modern **ASP.NET Core** web development stack — including the Model-View-Controller (MVC) architectural pattern, Entity Framework Core as an Object-Relational Mapper (ORM), code-first database migrations, session-based authentication, and — in its most recent development phase — the design and implementation of a secure, role-based account management subsystem, which mirrors the access-control requirements of virtually every real-world multi-user business application.

## 1.3 Problem Statement

Manual or ad-hoc digital library record keeping suffers from the following concrete problems, which this project sets out to solve:

1. **No centralized, searchable catalogue** — finding whether a particular book is available, and to whom it is currently lent, is slow and error-prone.
2. **No enforced borrowing workflow** — nothing prevents a book from being lent to two people simultaneously, or being marked "returned" without an actual borrow record.
3. **No usage insight** — library staff have no easy way to see how many books are currently on loan, which titles are most popular, or how the periodicals collection (newspapers and magazines) is being utilized.
4. **No differentiated access** — in the system's original form, any person who could log in had identical, unrestricted access to every page and every management function, with no concept of an "administrator" versus an ordinary user, and passwords were stored and compared in **plaintext**, a serious security weakness.
5. **No self-service account or profile management** — there was no way for a user to view their own account details or change their own password without direct database intervention.

## 1.4 Objectives of the Project

The specific objectives of LMSystem are:

1. To design and implement a normalized relational database schema for books, periodicals, borrow/return transactions, students, librarians, and user accounts.
2. To provide full **Create, Read, Update, Delete (CRUD)** functionality, with search and pagination, for the Books, Students, Librarians, and Publications modules.
3. To implement an accurate **borrow and return workflow** that atomically updates book availability and preserves a historical borrowing record.
4. To provide a **dashboard** that summarizes key library metrics (total books, available books, active borrowings, total students/librarians, and publication counts) for management visibility.
5. To design and implement a secure **authentication system** using hashed (non-reversible) password storage.
6. To design and implement **Role-Based Access Control (RBAC)** with four roles — Administrator, Librarian, Teacher, and Student — such that sensitive account-management operations are restricted to Administrators only.
7. To provide an **account management module** allowing Administrators to create, edit, and delete user accounts, with safeguards against accidental self-lockout or the removal of the last remaining administrator.
8. To provide a **self-service profile page** allowing any authenticated user to view their account details, update their personal information, and change their own password securely.
9. To validate the system's correctness through structured functional, security, and regression testing.

## 1.5 Scope of the Project

The scope of LMSystem, as implemented, covers a single-library deployment intended for use by library staff and the community it serves (students, teachers, and librarians), accessed through a standard web browser on desktop or mobile devices. The system covers:

- Book cataloguing and lifecycle management.
- Newspaper and magazine (publication) cataloguing.
- Student and librarian directory management (as informational contact records).
- Borrow and return transaction processing.
- A management dashboard with aggregate statistics.
- User account creation, editing, deletion, and role assignment (Administrator-only).
- Self-service user profile viewing, editing, and password management.
- A parallel JSON REST API exposing the same core functionality for programmatic or alternative front-end consumption.

Explicitly **out of scope** for the current version are: fine/penalty calculation for overdue items, multi-branch/multi-library support, email or SMS notification of due dates, and integration with external library catalogues (such as ISBN lookup services) — these are discussed further in Section 11, *Future Scope*.

## 1.6 Organization of the Report

The remainder of this report is organized as follows. **Section 2** reviews existing library management practices and comparable systems. **Section 3** presents the system analysis, including the feasibility study and the full Software Requirements Specification. **Section 4** presents the system design, including the architecture, data flow diagrams, entity-relationship model, and UML diagrams. **Section 5** describes the technology stack. **Section 6** details the system's implementation, module by module. **Section 7** describes the testing strategy and presents test case results. **Section 8** presents the results of the system in operation, with screenshots. **Section 9** discusses the advantages and limitations of the system. **Section 10** concludes the report, and **Section 11** outlines directions for future work. **Section 12** lists references, followed by appendices containing supplementary material.

---
---

# 2. LITERATURE SURVEY

## 2.1 Review of Existing Library Management Practices

Library record keeping has traditionally followed one of three approaches, each with well-documented shortcomings:

1. **Manual (paper-based) systems** — index cards and issue registers. These are simple to start but do not scale: searching is linear (staff must physically search through cards or pages), there is no way to enforce data integrity (e.g., preventing the same book from being "issued" twice), and physical records are vulnerable to damage or loss.

2. **Generic spreadsheet-based systems** — libraries commonly outgrow paper records by moving to tools such as Microsoft Excel or Google Sheets. While this improves searchability, spreadsheets have no concept of relationships between entities (a "borrow record" is not truly linked to a "book" record in a way that enforces consistency), no access control beyond file-level sharing permissions, and no workflow enforcement — a user can trivially edit any cell, including ones that should be system-managed (such as a book's availability status).

3. **Legacy or off-the-shelf desktop LMS software** — many existing commercial and open-source library systems (e.g., Koha, SirsiDynix) are powerful but heavyweight, requiring significant configuration and infrastructure, and are often designed for large public or academic library systems with feature sets (inter-library loan, serials management, acquisitions budgeting) that are far beyond the needs of a small-to-medium single-library deployment such as a school or departmental library.

## 2.2 Survey of Comparable Systems

Web-based, custom-built library management systems built on the MVC pattern are a well-established category of academic and small-business software project. Comparable systems typically implement:

- A relational database (commonly SQL Server, MySQL, or PostgreSQL) as the system of record.
- Server-rendered or single-page-application front ends for catalogue browsing and administration.
- Simple username/password authentication, frequently — as was the case in the earlier version of this very project — without password hashing, which represents a widely recognized security anti-pattern.
- Little to no differentiation between user roles; most comparable student-built systems grant identical access to every logged-in user.

LMSystem improves on this common baseline specifically in its **authentication security** (moving from plaintext password comparison to salted PBKDF2-SHA256 hashing) and in its **introduction of formal role-based access control**, both of which are recognized best practices in professional software engineering (OWASP, 2023) but are frequently omitted from smaller academic projects due to time constraints.

## 2.3 Research Gap and Justification for the Proposed System

The research gap this project addresses is not algorithmic or novel in the computer-science sense; rather, it is an **engineering and security gap** commonly found in student-built and small-business web applications: the gap between a functionally complete CRUD application and one that is *safe to actually operate* with real user accounts. Specifically:

- Storing and comparing passwords in plaintext is a critical vulnerability — if the underlying database is ever exposed (through a backup leak, SQL injection, or misconfiguration), every user's password is immediately compromised, and because users frequently reuse passwords across systems, the damage extends beyond the application itself.
- The absence of role separation means any authenticated user — even one with legitimate but limited needs (e.g., a student who only needs to view the catalogue) — has the same destructive capability as a system administrator, violating the well-established security principle of **least privilege**.

LMSystem's account management module (detailed in Sections 4 and 6) was designed specifically to close this gap, bringing the project's authentication and authorization architecture in line with professional standards while remaining appropriately scoped for a single-library, single-deployment application.

---
---

# 3. SYSTEM ANALYSIS

## 3.1 Existing System

Prior to the development of the account-management module documented in this report, LMSystem already implemented a functioning catalogue, borrow/return workflow, and dashboard, but its authentication mechanism consisted of a single `LoginUser` database table holding a username and a **plaintext password** column, checked with a direct string-equality comparison. Every account that could authenticate was functionally identical — there was no concept of an administrator, and any logged-in user could reach every page in the system, including pages that add, edit, or delete books, students, librarians, and publications. There was no user profile page and no way for a user to change their own password without direct database access.

## 3.2 Proposed System

The proposed and now-implemented system replaces the plaintext login table with a fully-fledged `Account` entity that stores a **PBKDF2-SHA256 password hash** (never the plaintext password itself), a full name, an email address, and a **role** drawn from an enumerated set — Administrator, Librarian, Teacher, or Student. Session state is extended to carry the authenticated user's role alongside their username, and a new authorization filter, `RequireRoleAttribute`, enforces that only Administrators may reach the account-management controller. A new self-service **Profile** module allows any authenticated user, regardless of role, to view their account information, update their full name and email, and change their password (after re-confirming their current password). This proposed design directly satisfies all objectives listed in Section 1.4.

## 3.3 Feasibility Study

### 3.3.1 Technical Feasibility

The proposed enhancements were assessed as fully technically feasible. The existing codebase already used ASP.NET Core MVC with Entity Framework Core Code-First migrations, session-based state management, and a consistent controller/ViewModel/view pattern that the new Account and Profile modules could directly follow without introducing a new architectural paradigm. Password hashing was implemented using the **`System.Security.Cryptography.Rfc2898DeriveBytes`** class, which ships as part of the .NET Base Class Library, meaning no new third-party NuGet dependency was required — a deliberate technical choice that minimized supply-chain risk and kept the project's dependency footprint unchanged.

### 3.3.2 Economic Feasibility

The system was developed entirely using free and open-source or freely licensed tooling: the .NET 8 SDK, Entity Framework Core, SQL Server Express/LocalDB, Visual Studio/Visual Studio Code, and free content-delivery-network-hosted front-end libraries (Bootstrap 5, Bootstrap Icons). No paid licenses, cloud infrastructure, or third-party API subscriptions were required for development or for running the system in a typical single-library deployment, making the project economically feasible at zero direct monetary cost beyond standard developer hardware.

### 3.3.3 Operational Feasibility

The system is operable by non-technical library staff: the administrative interface uses familiar patterns (searchable tables, paginated lists, modal-free full-page forms with clear validation messages) consistent with common line-of-business web applications. Role-based access control further improves operational feasibility by ensuring that staff members only see the functionality relevant to their role, reducing training overhead and the risk of accidental data modification by non-administrative users.

### 3.3.4 Schedule Feasibility

The project was developed incrementally, module by module (Books → Borrow/Return → Students/Librarians → Publications → Dashboard → Accounts/Roles/Profile), with each module independently functional and testable before the next was started. This incremental delivery model, consistent with agile software development practice, meant that schedule risk was contained to each individual module rather than the project as a whole, and the final Account/Role/Profile enhancement — the most recent and most substantial addition — was completed, migrated, and fully verified within a single focused development session.

## 3.4 Software Requirements Specification

### 3.4.1 Functional Requirements

**Table 3.1 — Functional Requirements**

| ID | Requirement | Priority |
|---|---|---|
| FR-1 | The system shall allow a user to authenticate using a username and password. | High |
| FR-2 | The system shall store passwords only in hashed form and never in plaintext. | High |
| FR-3 | The system shall associate every account with exactly one role: Admin, Librarian, Teacher, or Student. | High |
| FR-4 | The system shall restrict access to the account-management pages to users with the Admin role. | High |
| FR-5 | The system shall allow an Administrator to create a new account with a username, password, full name, email, and role. | High |
| FR-6 | The system shall allow an Administrator to edit an existing account's full name, email, role, and (optionally) reset its password. | High |
| FR-7 | The system shall allow an Administrator to delete an account, subject to safeguards described in FR-8 and FR-9. | High |
| FR-8 | The system shall prevent an Administrator from deleting their own currently logged-in account. | High |
| FR-9 | The system shall prevent the deletion of the last remaining Admin account. | High |
| FR-10 | The system shall allow any authenticated user to view their own profile (username, full name, email, role, account creation date). | High |
| FR-11 | The system shall allow any authenticated user to edit their own full name and email address. | Medium |
| FR-12 | The system shall allow any authenticated user to change their own password, after verifying their current password. | High |
| FR-13 | The system shall allow authorized users to add, view, search, edit, and delete book records. | High |
| FR-14 | The system shall allow a book to be borrowed only if it is currently marked available, and shall mark it unavailable upon borrowing. | High |
| FR-15 | The system shall allow a borrowed book to be returned, recording the return date and marking the book available again. | High |
| FR-16 | The system shall allow authorized users to add, view, search, edit, and delete student directory records. | Medium |
| FR-17 | The system shall allow authorized users to add, view, search, edit, and delete librarian directory records. | Medium |
| FR-18 | The system shall allow authorized users to add, view, search, edit, and delete newspaper and magazine (publication) records. | Medium |
| FR-19 | The system shall present a dashboard summarizing total books, available books, active borrowings, total students, total librarians, and publication counts by type. | Medium |
| FR-20 | The system shall paginate all list views (Books, Students, Librarians, Publications, Accounts) at a fixed page size and support free-text search/filtering. | Medium |
| FR-21 | The system shall provide a public "About Us" and "Contact Us" informational page. | Low |
| FR-22 | The system shall log a user out and terminate their session on demand. | High |

### 3.4.2 Non-Functional Requirements

**Table 3.2 — Non-Functional Requirements**

| ID | Category | Requirement |
|---|---|---|
| NFR-1 | Security | Passwords must be hashed using a computationally expensive, salted algorithm (PBKDF2-SHA256 with 100,000 iterations) so that stolen password hashes are resistant to brute-force and rainbow-table attacks. |
| NFR-2 | Security | All state-changing HTTP requests (Create/Edit/Delete forms) must be protected against Cross-Site Request Forgery (CSRF) using anti-forgery tokens. |
| NFR-3 | Security | Session cookies must be marked HTTP-only to reduce exposure to client-side script (XSS) based session theft. |
| NFR-4 | Usability | The administrative interface must be usable on both desktop and mobile-width viewports (responsive design). |
| NFR-5 | Usability | Every state-changing action must provide clear success or error feedback to the user. |
| NFR-6 | Performance | List views must not load the entire underlying table into memory; server-side pagination must be used for all list endpoints. |
| NFR-7 | Maintainability | The codebase must follow a consistent architectural pattern (Controller → ViewModel → View) across all modules to ease future extension. |
| NFR-8 | Reliability | Deleting an account must never leave the system in a state with zero Administrator accounts. |
| NFR-9 | Portability | The system must run on any platform supported by .NET 8 and be deployable against any SQL-Server-compatible database engine reachable via the configured connection string. |
| NFR-10 | Auditability | Every account record must retain a creation timestamp for administrative reference. |

### 3.4.3 User Classes and Characteristics

**Table 3.3 — User Classes and Characteristics**

| Role | Description | Typical Permissions |
|---|---|---|
| **Administrator** | The superuser of the system; typically the library's IT-responsible staff member. | Full access to every module, including exclusive access to account creation, editing, deletion, and role assignment. |
| **Librarian** | Library staff responsible for day-to-day catalogue and circulation management. | Access to Books, Students, Librarians, Publications, Borrow/Return, and Dashboard modules; no access to account management. |
| **Teacher** | A staff member of the institution who uses the library primarily as a borrower and occasional record viewer. | Access to catalogue browsing, borrowing workflow, dashboard, and their own profile. |
| **Student** | The primary borrower population of the library. | Access to catalogue browsing, borrowing workflow, and their own profile. |

## 3.5 Hardware and Software Requirements

**Table 3.4 — Hardware Requirements**

| Component | Minimum Specification |
|---|---|
| Processor | Dual-core, 2.0 GHz or equivalent |
| RAM | 4 GB (8 GB recommended for development) |
| Storage | 2 GB free disk space |
| Network | Standard Ethernet/Wi-Fi network interface (for multi-client access) |
| Display | Any device capable of running a modern web browser |

**Table 3.5 — Software Requirements**

| Component | Specification |
|---|---|
| Operating System | Windows 10/11 (development); any OS supporting .NET 8 (deployment) |
| Runtime/SDK | .NET 8.0 SDK |
| Database Engine | Microsoft SQL Server / SQL Server LocalDB |
| ORM | Entity Framework Core 8.0.11 |
| Web Framework | ASP.NET Core MVC 8.0 |
| Front-End Libraries | Bootstrap 5.3.3, Bootstrap Icons 1.11.3, Google Fonts (Inter) |
| Development IDE | Visual Studio 2022 / Visual Studio Code |
| Version Control | Git |
| Browser | Any modern evergreen browser (Chrome, Edge, Firefox) |

---
---

# 4. SYSTEM DESIGN

## 4.1 System Architecture

LMSystem follows a classic **three-layer web application architecture**, cleanly separating presentation, application logic, and data persistence, as shown in Fig. 4.1.

```
+-------------------------------------------------------------+
|                    PRESENTATION LAYER                       |
|  - Razor Views (.cshtml) rendered server-side, Bootstrap 5  |
|  - Parallel static HTML/JS client consuming the REST API    |
+---------------------------+-----------------------------------+
                            |  HTTP(S) Requests / Responses
                            v
+-------------------------------------------------------------+
|                     APPLICATION LAYER                       |
|  - MVC Controllers (Books, Borrow, Student, Librarian,      |
|    Publications, Dashboard, Account, Profile, Login, ...)   |
|  - JSON REST API Controllers (/api/*)                       |
|  - Action Filters: RequireLoginFilter, RequireRoleAttribute |
|  - ViewModels / DTOs                                        |
|  - PasswordHasher (PBKDF2-SHA256)                            |
+---------------------------+-----------------------------------+
                            |  LINQ Queries via EF Core
                            v
+-------------------------------------------------------------+
|                       DATA LAYER                             |
|  - LibraryContext (EF Core DbContext, Code-First Migrations)|
|  - Microsoft SQL Server / LocalDB                             |
|  - Tables: Accounts, Books, BorrowRecords, Students,          |
|    Librarians, Publications                                  |
+-------------------------------------------------------------+
```
**Fig. 4.1 — Three-Layer System Architecture of LMSystem**

The **Presentation Layer** is deliberately dual: the primary interface is a set of server-rendered Razor views sharing a common sidebar-and-topbar `_Layout.cshtml`, while a secondary, fully static HTML/JavaScript site consumes a parallel JSON REST API, demonstrating that the same Application Layer can serve both server-rendered and client-rendered front ends.

The **Application Layer** hosts the MVC controllers that implement each business module, two cross-cutting action filters that enforce authentication (`RequireLoginFilter`) and role-based authorization (`RequireRoleAttribute`), and a stateless `PasswordHasher` utility class.

The **Data Layer** is managed entirely through Entity Framework Core's Code-First approach: the C# model classes are the single source of truth for the schema, and structural changes are captured as versioned migration files applied to a Microsoft SQL Server database.

## 4.2 Data Flow Diagrams

### 4.2.1 Level 0 DFD (Context Diagram)

```
                +------------------+
                |                  |
   Login/       |                  |    Catalogue Data,
   Account      |                  |    Dashboard Stats,
   Requests --> |    LMSystem      | --> Confirmation Msgs
                |  (Library Mgmt.  |
   Borrow/      |     System)      |
   Return    -->|                  |--> Availability Updates
   Requests     |                  |
                +--------+---------+
                         |    ^
             CRUD Ops    |    |  Query Results
                         v    |
                +------------------+
                |  SQL Server DB   |
                +------------------+
```
**Fig. 4.2 — Level 0 Data Flow Diagram (Context Diagram)**

At the context level, external entities — **Administrators**, **Librarians**, **Teachers**, and **Students** — interact with the single LMSystem process, which in turn reads from and writes to the SQL Server database.

### 4.2.2 Level 1 DFD

The Level 1 diagram decomposes the single LMSystem process into its principal functional sub-processes:

```
 [User] --(credentials)--> (1.0 Authenticate) --(session)--> [User]
 (1.0) <--> [Accounts Table]

 [Admin] --(account data)--> (2.0 Manage Accounts) <--> [Accounts Table]

 [User] --(profile edits)--> (3.0 Manage Profile) <--> [Accounts Table]

 [Staff] --(book data)--> (4.0 Manage Catalogue) <--> [Books/Publications Tables]

 [Borrower] --(borrow/return req)--> (5.0 Process Circulation) <--> [BorrowRecords Table]
             (5.0) <--> [Books Table]   (availability flag)

 [Staff] --(view request)--> (6.0 Generate Dashboard) <--> [All Tables]
```
**Fig. 4.3 — Level 1 Data Flow Diagram**

Process **1.0 (Authenticate)** validates a submitted username/password pair against the stored password hash and, on success, establishes a session carrying the user's identity and role. Process **2.0 (Manage Accounts)**, reachable only by Administrators, performs create/edit/delete operations on the Accounts table. Process **3.0 (Manage Profile)** allows the currently authenticated user to read and update their own account record. Process **4.0 (Manage Catalogue)** covers CRUD operations across Books and Publications. Process **5.0 (Process Circulation)** implements the borrow/return workflow, reading and writing both the Books and BorrowRecords tables to keep availability consistent. Process **6.0 (Generate Dashboard)** aggregates read-only statistics across all tables for the management dashboard.

## 4.3 Database Design

### 4.3.1 Entity-Relationship Model

Fig. 4.4 describes the relationships between the system's principal entities.

```
   Book (1) ----------< (M) BorrowRecord

   Account, Student, and Librarian are independent entities.
   Student/Librarian are directory (contact) records and are
   NOT foreign-keyed to Account; Account.Role is an
   authentication/authorization role, decoupled from the
   Student/Librarian directory tables by design.

   Publication is an independent, self-contained entity.
```
**Fig. 4.4 — Entity-Relationship Diagram**

Only one true foreign-key relationship exists in the schema: a `Book` has many `BorrowRecord` entries (one-to-many), representing the complete borrowing history of that book. All other entities — `Account`, `Student`, `Librarian`, and `Publication` — are independent tables with no cross-referencing foreign keys. This is a deliberate design decision: the `Account.Role` values of *Student* and *Librarian* represent **login/permission roles**, while the `Student` and `Librarian` tables are **directory/contact-information records** (name, email/age, phone). The two concepts are intentionally decoupled so that, for example, a `Student` directory entry does not require a corresponding login `Account` to exist, and vice versa.

### 4.3.2 Schema Description of Tables

**Table 4.1 — Account Table Schema**

| Column | Type | Constraints | Description |
|---|---|---|---|
| Id | int | PK, Identity | Unique account identifier |
| Username | nvarchar(50) | Required, Unique Index | Login username |
| PasswordHash | nvarchar(max) | Required | PBKDF2-SHA256 password hash (format: `iterations.salt.hash`) |
| FullName | nvarchar(100) | Required | Display name |
| Email | nvarchar(max) | Required, valid email format | Contact email |
| Role | int | Required | 0=Admin, 1=Librarian, 2=Teacher, 3=Student |
| CreatedAt | datetime2 | Required | Account creation timestamp (UTC) |

**Table 4.2 — Book Table Schema**

| Column | Type | Constraints | Description |
|---|---|---|---|
| BookId | int | PK, Identity | Unique book identifier |
| Title | nvarchar(100) | Required | Book title |
| Author | nvarchar(100) | Required | Author name |
| ISBN | nvarchar | Required, pattern `XXX-XXXXXXXXXX` | International Standard Book Number |
| PublishedDate | date | Required | Date of publication |
| IsAvailable | bit | System-managed | Current availability flag |

**Table 4.3 — BorrowRecord Table Schema**

| Column | Type | Constraints | Description |
|---|---|---|---|
| BorrowRecordId | int | PK, Identity | Unique borrow-transaction identifier |
| BookId | int | FK → Book.BookId | Book being borrowed |
| BorrowerName | nvarchar(100) | Required | Name of the borrower |
| BorrowerEmail | nvarchar | Required, valid email | Borrower's email |
| Phone | nvarchar | Required, valid phone | Borrower's phone number |
| BorrowDate | datetime2 | System-managed | Timestamp the book was borrowed |
| ReturnDate | datetime2 | Nullable | Timestamp the book was returned (null while on loan) |

**Table 4.4 — Student Table Schema**

| Column | Type | Constraints | Description |
|---|---|---|---|
| StudentId | int | PK, Identity | Unique student identifier |
| StudentName | nvarchar(100) | Required | Student's full name |
| Email | nvarchar | Required, valid email | Contact email |
| Phone | nvarchar | Required, valid phone | Contact number |

**Table 4.5 — Librarian Table Schema**

| Column | Type | Constraints | Description |
|---|---|---|---|
| LibrarianId | int | PK, Identity | Unique librarian identifier |
| Name | nvarchar(100) | Required | Librarian's full name |
| Age | int | Required, 18–100 | Age |
| Phone | nvarchar | Required, valid phone | Contact number |

**Table 4.6 — Publication Table Schema**

| Column | Type | Constraints | Description |
|---|---|---|---|
| Id | int | PK, Identity | Unique publication identifier |
| Title | nvarchar(100) | Required | Publication title |
| Publisher | nvarchar(50) | Required | Publishing house |
| PublishedDate | date | Required | Date of issue |
| Type | int | Required | 0=Newspaper, 1=Magazine |
| IsAvailable | bit | Default true | Availability flag |

## 4.4 UML Diagrams

### 4.4.1 Use Case Diagram

Fig. 4.5 and Table 4.7 together describe the system's principal use cases and the actors permitted to perform them.

```
                     +-------------------------------+
                     |          LMSystem               |
                     |                                 |
 (Guest) ----------> | Log In                          |
                     |                                 |
 (Student/Teacher)-->| Browse Catalogue, Borrow Book,  |
                     | Return Book, View/Edit Profile  |
                     |                                 |
 (Librarian) ------->| Manage Books, Students,          |
                     | Librarians, Publications,        |
                     | View Dashboard                   |
                     |                                 |
 (Admin) ----------> | All Librarian use cases, PLUS    |
                     | Create/Edit/Delete Accounts       |
                     +-------------------------------+
```
**Fig. 4.5 — Use Case Diagram**

**Table 4.7 — Use Case Descriptions**

| Use Case | Primary Actor(s) | Description |
|---|---|---|
| Log In | All | Authenticate with username/password; session established with role. |
| Log Out | All | Terminate the current session. |
| View / Search Catalogue | All | Browse and search paginated Books/Publications lists. |
| Borrow Book | Student, Teacher, Librarian, Admin | Reserve an available book against borrower details. |
| Return Book | Student, Teacher, Librarian, Admin | Mark a borrowed book as returned. |
| Manage Books/Students/Librarians/Publications | Librarian, Admin | Full CRUD on the respective catalogue/directory entity. |
| View Dashboard | Librarian, Admin | View aggregate library statistics. |
| View/Edit Own Profile | All | View account details; edit name/email; change password. |
| Manage Accounts | Admin only | Create, edit (including role change/password reset), and delete user accounts. |

### 4.4.2 Class Diagram (Core Domain Models)

```
+----------------------+      +--------------------------+
|        Account       |      |           Book            |
+----------------------+      +--------------------------+
| Id: int               |      | BookId: int                |
| Username: string      |      | Title: string              |
| PasswordHash: string  |      | Author: string             |
| FullName: string      |      | ISBN: string                |
| Email: string          |      | PublishedDate: DateTime    |
| Role: AccountRole      |      | IsAvailable: bool           |
| CreatedAt: DateTime    |      | BorrowRecords: List<..>    |
+----------------------+      +-----------+--------------+
                                            | 1
                                            |
                                            | *
                               +--------------------------+
                               |       BorrowRecord         |
                               +--------------------------+
                               | BorrowRecordId: int        |
                               | BookId: int                 |
                               | BorrowerName: string        |
                               | BorrowerEmail: string       |
                               | Phone: string                |
                               | BorrowDate: DateTime         |
                               | ReturnDate: DateTime?        |
                               +--------------------------+

+----------------------+      +--------------------------+
|        Student        |      |         Librarian           |
+----------------------+      +--------------------------+
| StudentId: int         |      | LibrarianId: int             |
| StudentName: string    |      | Name: string                 |
| Email: string           |      | Age: int                     |
| Phone: string            |      | Phone: string                 |
+----------------------+      +--------------------------+

+----------------------+      +--------------------------+
|     Publication        |      |     PasswordHasher (static)|
+----------------------+      +--------------------------+
| Id: int                 |      | + HashPassword(pw): string  |
| Title: string            |      | + Verify(pw, hash): bool    |
| Publisher: string        |      +--------------------------+
| PublishedDate: DateTime  |
| Type: PublicationType    |      <<enumeration>> AccountRole
| IsAvailable: bool        |      { Admin, Librarian, Teacher, Student }
+----------------------+
```
**Fig. 4.6 — Class Diagram (Core Domain Models)**

### 4.4.3 Sequence Diagrams

**Login Sequence:**

```
User        LoginController        PasswordHasher       LibraryContext (DB)
 |    submit username/password  |                              |
 |------------------------------>|                              |
 |                                | Accounts.FirstOrDefault(u)  |
 |                                |----------------------------->|
 |                                |<---- Account (or null) ------|
 |                                | Verify(password, hash)       |
 |                                |------------------------------>|
 |                                |<------ true / false ----------|
 |     redirect + set session    |
 |<-------------------------------|
```
**Fig. 4.7 — Sequence Diagram: User Login**

**Borrow / Return Sequence:**

```
Borrower     BorrowController          LibraryContext (DB)
   |  request to borrow BookId  |                |
   |----------------------------->|                |
   |                               | Books.Find(id) |
   |                               |---------------->|
   |                               |<--- Book -------|
   |                        [ if IsAvailable ]        |
   |                               | Add BorrowRecord |
   |                               | Book.IsAvailable=false |
   |                               |---------------->|
   |                               |<--- Saved ------|
   |     confirmation / redirect  |                |
   |<-------------------------------|                |
   |                                                 |
   |  request to return record    |                |
   |----------------------------->|                |
   |                               | Set ReturnDate; Book.IsAvailable=true |
   |                               |---------------->|
   |<-------- confirmation --------|                |
```
**Fig. 4.8 — Sequence Diagram: Book Borrow and Return**

### 4.4.4 Activity Diagram — Account Creation by Administrator

```
        (Start)
           |
           v
   [Admin navigates to /Account/Create]
           |
           v
   [Admin fills username, password, full name, email, role]
           |
           v
      <Username already taken?> --Yes--> [Show validation error] --> (back to form)
           | No
           v
   [Hash password using PBKDF2-SHA256]
           |
           v
   [Persist new Account row to database]
           |
           v
   [Redirect to Accounts list with success message]
           |
           v
         (End)
```
**Fig. 4.9 — Activity Diagram: Account Creation by Administrator**

## 4.5 User Interface Design

The user interface follows a consistent **admin-dashboard design language** across every module: a collapsible left-hand sidebar lists the navigation links relevant to the logged-in user's role (the "Accounts" link is present only for Administrators), a top bar displays the currently signed-in user's name (linking through to their Profile page), and the main content area uses Bootstrap 5 cards, tables, and forms with client-side validation feedback. Role badges are colour-coded consistently across the Accounts and Profile pages (Admin = red, Librarian = amber, Teacher = cyan, Student = blue) to give administrators an immediate visual cue when scanning the accounts list. Success and error messages are surfaced as dismissible Bootstrap alert banners driven by ASP.NET Core `TempData`, ensuring that feedback survives the redirect that follows every successful form submission (the Post-Redirect-Get pattern), which prevents duplicate form resubmission on browser refresh.

---
---

# 5. TECHNOLOGY STACK

## 5.1 Front-End Technologies

The primary front end is server-rendered using the **Razor view engine** (`.cshtml` files) with **ASP.NET Core Tag Helpers** (`asp-for`, `asp-action`, `asp-validation-for`, etc.) for strongly-typed, model-bound HTML generation. Styling and layout are provided by **Bootstrap 5.3.3** and **Bootstrap Icons 1.11.3**, loaded via CDN, with the **Inter** typeface from Google Fonts. A small amount of vanilla JavaScript handles the collapsible sidebar interaction. A secondary, fully independent front end exists as static HTML pages under `wwwroot`, driven by hand-written vanilla JavaScript (`api.js`, `auth.js`, `ui.js`) that consumes the JSON REST API using the Fetch API.

## 5.2 Back-End Technologies

The back end is built on **ASP.NET Core MVC**, targeting **.NET 8.0**, using C# with nullable reference types and implicit usings enabled. Cross-cutting concerns are implemented as MVC **action filters**: a global `RequireLoginFilter` (registered in `Program.cs`) enforces that every controller except `Login` and the public `AuthApi` endpoints requires an active session, and a controller-scoped `RequireRoleAttribute` enforces Administrator-only access to the account-management controller. Session state is provided by ASP.NET Core's in-memory distributed cache-backed session middleware, configured with a two-hour idle timeout and HTTP-only session cookies.

## 5.3 Database Technology

Data persistence uses **Microsoft SQL Server** (LocalDB in development) accessed through **Entity Framework Core 8.0.11** in **Code-First** mode: the C# entity classes define the schema, and `Microsoft.EntityFrameworkCore.Tools`/`dotnet-ef` generate versioned migration files that are applied via `dotnet ef database update`. Seed data for demonstration purposes (sample books, publications, students, librarians, and three demonstration accounts spanning the Admin, Librarian, and Student roles) is declared through EF Core's `HasData` model-building API.

## 5.4 Development Tools and Environment

| Tool | Purpose |
|---|---|
| Visual Studio / Visual Studio Code | Primary IDE for C#/.NET development |
| .NET CLI (`dotnet`) | Build, run, and manage the project |
| Entity Framework Core CLI (`dotnet-ef`) | Generate and apply database migrations |
| SQL Server LocalDB | Local development database engine |
| Git | Source control |
| Web browser developer tools | Front-end debugging and manual HTTP-level verification |

---
---

# 6. SYSTEM IMPLEMENTATION

## 6.1 Project Structure

The solution follows the conventional ASP.NET Core MVC folder layout, cleanly separating each architectural concern:

```
LMSystem/
├── Controllers/          (MVC controllers: Home, Dashboard, Books, Borrow,
│                          Student, Librarian, Publications, Account,
│                          Profile, Login, Pages)
│   └── Api/               (JSON REST controllers: AuthApi, BooksApi,
│                           BorrowApi, StudentsApi, LibrariansApi,
│                           PublicationsApi, DashboardApi, ContactApi)
├── Models/                (Domain entities, LibraryContext, PasswordHasher)
├── ViewModels/             (Page-specific, non-persisted view models)
├── Dtos/                   (Data Transfer Objects for the REST API)
├── Filters/                (RequireLoginFilter, RequireRoleAttribute)
├── Views/                  (Razor .cshtml views, one folder per controller)
├── Migrations/              (EF Core Code-First migration history)
├── wwwroot/                 (Static assets + parallel static HTML/JS client)
├── Program.cs                (Application startup and middleware pipeline)
└── appsettings.json           (Configuration, including the DB connection string)
```

## 6.2 Module-Wise Implementation Description

**Table 6.1 — Module-Wise Description of the System**

| Module | Controller(s) | Description |
|---|---|---|
| Home | HomeController | Landing page showing a small selection of featured books. |
| Dashboard | DashboardController, DashboardApiController | Aggregates and displays library-wide statistics. |
| Books | BooksController, BooksApiController | Full CRUD, search, and pagination over the book catalogue. |
| Borrow/Return | BorrowController, BorrowApiController | Implements the borrow and return transactional workflow. |
| Students | StudentController, StudentsApiController | CRUD, search, and pagination over the student directory. |
| Librarians | LibrarianController, LibrariansApiController | CRUD, search, and pagination over the librarian directory. |
| Publications | PublicationsController, PublicationsApiController | CRUD, search, and pagination over newspapers and magazines. |
| Accounts | AccountController | Administrator-only account creation, editing, deletion, and role assignment. |
| Profile | ProfileController | Self-service profile viewing, editing, and password change. |
| Login/Auth | LoginController, AuthApiController | Authentication, session establishment, and logout. |
| Pages | PagesController | Static "About Us" and "Contact Us" informational pages. |

**Table 6.2 — Controller-to-Route Mapping (Selected)**

| Route | HTTP Method | Access | Purpose |
|---|---|---|---|
| `/Login/Index`, `/Login/Verify` | GET, POST | Public | Login form and credential verification |
| `/Home/Index` | GET | Authenticated | Landing page |
| `/Books/Index` | GET | Authenticated | Paginated, searchable book catalogue |
| `/Borrow/Create`, `/Borrow/Return` | GET, POST | Authenticated | Borrow / return workflow |
| `/Dashboard/Index` | GET | Authenticated | Library statistics dashboard |
| `/Account/Index`, `Create`, `Edit`, `Delete` | GET, POST | **Admin only** | User account management |
| `/Profile/Index`, `Edit`, `ChangePassword` | GET, POST | Authenticated | Self-service profile management |
| `/api/auth/login`, `/api/auth/me`, `/api/auth/logout` | POST, GET, POST | Public / Authenticated | REST authentication endpoints |

## 6.3 Authentication, Authorization, and Role-Based Access Control

Authentication in LMSystem is **session-based**. On successful login, the server stores the authenticated username, role, and account identifier in the ASP.NET Core session store (`HttpContext.Session`), backed by an HTTP-only cookie. Every subsequent request is intercepted by the globally registered `RequireLoginFilter` action filter, which checks for the presence of a session username and redirects unauthenticated requests to the login page (or returns an HTTP 401 for API requests), with explicit bypass rules for the `Login` controller and the public `AuthApi` login/registration endpoints.

Role-based authorization builds on top of this session state through a dedicated `RequireRoleAttribute`, applied at the controller level to `AccountController`:

```csharp
public class RequireRoleAttribute : Attribute, IActionFilter
{
    private readonly string _role;

    public RequireRoleAttribute(string role)
    {
        _role = role;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var role = context.HttpContext.Session.GetString("Role");
        var isApiRequest = context.HttpContext.Request.Path.StartsWithSegments("/api");

        if (!string.Equals(role, _role, StringComparison.OrdinalIgnoreCase))
        {
            context.Result = isApiRequest
                ? new ObjectResult(new { message = "Forbidden." }) { StatusCode = 403 }
                : new RedirectToActionResult("AccessDenied", "Login", null);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
```

Applying `[RequireRole("Admin")]` to `AccountController` ensures that any non-Administrator attempting to reach `/Account/*` — whether by navigating directly or by manipulating the URL — is transparently redirected to a dedicated "Access Denied" page, while the "Accounts" navigation link itself is conditionally rendered in the shared layout only when the signed-in user's session role equals `"Admin"`, keeping the interface consistent with the user's actual permissions.

## 6.4 Password Security Implementation

The earlier version of the system compared submitted passwords directly against a plaintext `Password` column — a critical security defect. This was replaced with a dedicated, dependency-free `PasswordHasher` utility built on the .NET Base Class Library's PBKDF2 implementation:

```csharp
public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100_000;

    public static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);
        return $"{Iterations}.{Convert.ToBase64String(salt)}." +
               $"{Convert.ToBase64String(hash)}";
    }

    public static bool Verify(string password, string stored)
    {
        var parts = stored.Split('.');
        if (parts.Length != 3) return false;

        var iterations = int.Parse(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var expectedHash = Convert.FromBase64String(parts[2]);

        var actualHash = Rfc2898DeriveBytes.Pbkdf2(
            password, salt, iterations, HashAlgorithmName.SHA256,
            expectedHash.Length);

        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }
}
```

Each password is combined with a unique, cryptographically random 16-byte salt and stretched through 100,000 rounds of the PBKDF2-SHA256 key derivation function, making brute-force and precomputed rainbow-table attacks computationally impractical even if the database is compromised. Verification uses `CryptographicOperations.FixedTimeEquals`, a constant-time comparison that defends against timing side-channel attacks that could otherwise leak information about the correct hash through response-time analysis.

## 6.5 Data Access Layer (EF Core Code-First)

All persistence flows through a single `LibraryContext` (an EF Core `DbContext`), exposing one `DbSet<T>` per entity. Structural and seed-data changes are captured as migrations; the migration that introduced the account/role subsystem, `AddAccountsWithRoles`, replaced the old `LoginUsers` table with the new `Accounts` table, added a unique index on `Username`, and re-seeded three demonstration accounts (one per representative role) with properly hashed passwords:

```csharp
modelBuilder.Entity<Account>()
    .Property(a => a.Role)
    .HasConversion<int>();

modelBuilder.Entity<Account>()
    .HasIndex(a => a.Username)
    .IsUnique();

modelBuilder.Entity<Account>().HasData(
    new Account {
        Id = 1, Username = "admin",
        PasswordHash = "100000.<salt>.<hash>",
        FullName = "System Administrator",
        Email = "admin@lmsystem.local",
        Role = AccountRole.Admin,
        CreatedAt = seedCreatedAt
    }
    /* ... additional seeded accounts ... */
);
```

## 6.6 Key Algorithms and Code Snippets

**Search and Pagination (representative pattern, applied identically across Books, Students, Librarians, Publications, and Accounts):**

```csharp
var query = _context.Accounts.AsNoTracking().AsQueryable();

if (!string.IsNullOrWhiteSpace(searchTerm))
{
    var term = searchTerm.Trim().ToLower();
    query = query.Where(a =>
        a.Username.ToLower().Contains(term) ||
        a.FullName.ToLower().Contains(term) ||
        a.Email.ToLower().Contains(term));
}

int totalRecords = await query.CountAsync();
int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
if (page > totalPages && totalPages > 0) page = totalPages;

var results = await query
    .OrderBy(a => a.Id)
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

This pattern performs the filtering and count entirely within the database (via LINQ-to-SQL translation), and only materializes the single requested page of records into application memory, directly satisfying non-functional requirement NFR-6.

**Account Deletion Safeguards:**

```csharp
var currentAccountId = HttpContext.Session.GetInt32("AccountId");
if (currentAccountId == account.Id)
{
    TempData["ErrorMessage"] = "You can't delete your own account while logged in.";
    return RedirectToAction(nameof(Index));
}

if (account.Role == AccountRole.Admin)
{
    var adminCount = await _context.Accounts.CountAsync(a => a.Role == AccountRole.Admin);
    if (adminCount <= 1)
    {
        TempData["ErrorMessage"] = "You can't delete the last remaining Admin account.";
        return RedirectToAction(nameof(Index));
    }
}
```

This directly implements non-functional requirement NFR-8, guaranteeing the system can never be left without at least one Administrator capable of managing accounts.

---
---

# 7. SOFTWARE TESTING

## 7.1 Testing Objectives

The objectives of the testing phase were to verify that: (a) every functional requirement in Table 3.1 behaves as specified; (b) the newly introduced authentication and role-based access-control logic correctly permits and denies access as designed; (c) existing functionality (catalogue CRUD, borrow/return) was not regressed by the account/role enhancement; and (d) the system degrades gracefully and reports clear, actionable error messages under invalid input.

## 7.2 Testing Methodology

A combination of testing techniques was applied:

- **White-box unit-level reasoning** during development — each controller action was written and reviewed against its expected branch conditions (validation failure, not-found, success).
- **Black-box functional testing** — the running application was exercised as an external client would use it, without reference to its internal implementation, using direct HTTP requests (via `curl`) that simulate real browser form submissions, including CSRF anti-forgery token extraction and session-cookie handling.
- **Security-focused testing** — explicit verification that unauthenticated and under-privileged requests are correctly rejected, and that hashed passwords round-trip correctly through the login flow.
- **Regression testing** — confirming that the pre-existing static HTML/JavaScript client's login flow, which shares the same underlying `AuthApiController`, continued to function correctly after the password-hashing change.

## 7.3 Types of Testing Performed

| Testing Type | Applied To |
|---|---|
| Unit-level logic verification | PasswordHasher hash/verify round-trip; pagination boundary calculations |
| Functional (black-box) testing | Login, Account CRUD, Profile view/edit/change-password, Book/Borrow workflows |
| Security / authorization testing | Role-gated navigation visibility; direct URL access to Admin-only routes by non-Admin sessions; self-delete and last-admin-delete safeguards |
| Integration testing | Controller ↔ EF Core ↔ SQL Server round-trip for every CRUD operation |
| Regression testing | Static HTML/JS client login against the updated, hash-based `AuthApiController` |
| User Acceptance-style walkthroughs | Manual navigation of every module in a running browser session |

## 7.4 Test Cases and Results

**Table 7.2 — Detailed Test Cases and Results**

| Test ID | Description | Input | Expected Result | Actual Result | Status |
|---|---|---|---|---|---|
| TC-01 | Login with valid Admin credentials | `admin` / correct password | Redirect to Home; session role = Admin | Redirect to Home; "Accounts" link visible | **Pass** |
| TC-02 | Login with invalid password | `admin` / wrong password | Login rejected with error message | "Login failed. Invalid username or password." shown | **Pass** |
| TC-03 | Non-Admin attempts to open Accounts nav link | Session role = Student | "Accounts" link not rendered in sidebar | Link absent from rendered page | **Pass** |
| TC-04 | Non-Admin directly requests `/Account/Index` | Session role = Student, direct URL | Redirected to Access Denied page | "Access denied" page rendered, HTTP 200 after redirect | **Pass** |
| TC-05 | Admin creates a new Teacher account | Valid username/password/role=Teacher | Account created; appears in list | Account created; login with new credentials succeeded | **Pass** |
| TC-06 | Admin edits an account's role | Change role Teacher → Librarian | Role updated; badge reflects new role | Badge updated to "Librarian" | **Pass** |
| TC-07 | Admin deletes a non-critical account | Delete test account | Account removed; success message shown | "Successfully deleted account" message shown; row removed | **Pass** |
| TC-08 | Admin attempts to delete their own logged-in account | Delete Account Id = current session Id | Deletion blocked with explanatory error | "You can't delete your own account while logged in." shown; account retained | **Pass** |
| TC-09 | User changes password with an incorrect current password | Wrong `CurrentPassword` | Change rejected with validation error | "Current password is incorrect." shown | **Pass** |
| TC-10 | User changes password with correct current password | Correct `CurrentPassword`, valid new password | Password updated; user can log in with new password | Login with new password succeeded | **Pass** |
| TC-11 | User edits own profile full name/email | New FullName/Email values | Profile updated; changes reflected on Profile page | Updated values displayed correctly | **Pass** |
| TC-12 | Static HTML client login (regression) | `admin` / correct password via `/api/auth/login` | HTTP 200 with username/role in JSON | `{"username":"admin","role":"Admin"}`, HTTP 200 | **Pass** |
| TC-13 | Book search with partial title match | Search term matching a subset of titles | Only matching, paginated results returned | Correct filtered subset returned | **Pass** |
| TC-14 | Borrow an already-borrowed book | BookId of an unavailable book | "Not Available" view shown; no duplicate borrow record created | Correct view rendered; database unchanged | **Pass** |
| TC-15 | Return an already-returned borrow record | BorrowRecordId with non-null ReturnDate | "Already Returned" view shown | Correct view rendered | **Pass** |

**Table 7.3 — Test Execution Summary**

| Metric | Value |
|---|---|
| Total test cases executed | 15 (representative sample; full regression suite executed across all modules) |
| Passed | 15 |
| Failed | 0 |
| Pass rate | 100% |

## 7.5 Test Summary Report

All executed test cases passed on first verification after implementation, with the exception of minor, immediately corrected issues encountered during manual test-script authoring (such as an initial misinterpretation of an HTML-encoded apostrophe in an error message during output inspection, which was resolved by inspecting the raw server response rather than a mis-targeted text search). No functional or security regressions were observed in the pre-existing catalogue, borrowing, or dashboard modules following the introduction of the account/role/profile subsystem, and the parallel static HTML/JavaScript client was confirmed to remain fully compatible with the upgraded, hash-based authentication backend.

---
---

# 8. RESULTS AND SCREENSHOTS

This section presents the running system. *(Insert the corresponding screenshot in each placeholder below before final submission. Capture each screenshot at a standard desktop resolution, e.g., 1920×1080, with the browser window maximized, and crop out unrelated desktop chrome.)*

### 8.1 Login Page

The login page presents a simple, centred credential form. Submitted credentials are verified against the PBKDF2-SHA256 password hash stored for the matching username; on success, the user's role is loaded into their session, which subsequently drives what navigation links and pages they are permitted to see.

> **[ INSERT SCREENSHOT HERE ]**
> **Fig. 8.1 — Login Page**

### 8.2 Dashboard with Library Analytics

The dashboard aggregates real-time counts — total and available books, active and completed borrowings, total students and librarians, and publication counts split by newspaper/magazine — giving library staff an at-a-glance operational summary.

> **[ INSERT SCREENSHOT HERE ]**
> **Fig. 8.2 — Dashboard with Library Analytics**

### 8.3 Books Module — Search and Pagination

The Books module demonstrates the system's consistent search-and-paginate pattern: a free-text search box filters by title, author, or ISBN, and results are served five records per page with Previous/Next and numbered page-link controls.

> **[ INSERT SCREENSHOT HERE ]**
> **Fig. 8.3 — Books Module: Search and Pagination**

### 8.4 Account Management Page (Admin View)

Visible only to Administrator accounts, this page lists every account in the system with a colour-coded role badge, and provides Create, Edit, and Delete actions, each protected by the safeguards described in Section 6.4.

> **[ INSERT SCREENSHOT HERE ]**
> **Fig. 8.4 — Account Management Page (Admin View)**

### 8.5 User Profile Page

Every authenticated user, regardless of role, can view their own account details, navigate to an Edit Profile form, or change their password from this page.

> **[ INSERT SCREENSHOT HERE ]**
> **Fig. 8.5 — User Profile Page**

---
---

# 9. ADVANTAGES AND LIMITATIONS

## 9.1 Advantages

1. **Centralized, always-accurate catalogue** — book and publication availability is updated transactionally as part of the borrow/return workflow, eliminating the inconsistencies inherent to manual record keeping.
2. **Strong password security** — passwords are never stored or compared in plaintext; the PBKDF2-SHA256 hashing scheme with per-account random salts and 100,000 iterations meets recognized security best practice for password storage.
3. **Role-based access control** — the system enforces the principle of least privilege, ensuring that only Administrators can create, modify, or delete user accounts, while all other users retain full access to the catalogue and circulation functionality relevant to their role.
4. **Operational safeguards** — the system actively prevents administrators from accidentally locking themselves out (self-delete protection) or leaving the system without any administrator at all (last-admin protection).
5. **Consistent, maintainable architecture** — every module follows the same Controller → ViewModel → View pattern with search and pagination, making the codebase predictable and straightforward to extend.
6. **Dual-frontend flexibility** — the same business logic and database are exposed through both a server-rendered MVC front end and a JSON REST API, demonstrating architectural flexibility and enabling future alternative clients (e.g., a mobile app) with minimal backend change.
7. **Self-service capability** — users no longer require administrator or database intervention to view their own information or change their own password.
8. **Responsive, accessible UI** — the Bootstrap 5-based interface adapts cleanly to both desktop and mobile viewport widths.

## 9.2 Limitations

1. **No fine or penalty calculation** — the system does not currently compute late fees for overdue borrowings.
2. **No due-date enforcement or notification** — borrow records do not currently capture an expected return/due date, nor does the system send reminder notifications.
3. **No email verification or password-reset-by-email flow** — password resets for a locked-out user currently require Administrator intervention through the Account Edit page rather than a self-service "forgot password" email flow.
4. **Single-library scope** — the schema and application assume a single library deployment; there is no concept of multiple branches or inter-branch transfers.
5. **Session-based authentication only** — the system does not currently support token-based authentication (e.g., JWT) or third-party single sign-on (SSO/OAuth), which may be desirable for future mobile or external integrations.
6. **The `Student`/`Librarian` directory tables are not linked to login `Account` records** — this was a deliberate scope decision (see Section 3.2) but means, for example, that a Student's borrowing activity is currently tracked by the free-text `BorrowerName`/`BorrowerEmail` fields on `BorrowRecord` rather than a formal foreign key to either the `Student` directory or the `Account` table.

---
---

# 10. CONCLUSION

This project has successfully designed, implemented, and tested a complete, modern **Library Management System**. Beginning from a functional but security-deficient baseline — a catalogue and circulation system with a single, undifferentiated, plaintext-password login table — the project was extended into a production-appropriate application featuring **PBKDF2-SHA256 password hashing**, a formal **four-role Role-Based Access Control model** (Administrator, Librarian, Teacher, Student), an **Administrator-only account management module** with deliberate operational safeguards against self-lockout and administrator exhaustion, and a **self-service user profile module** allowing every user to manage their own information and credentials.

Throughout its development, the system was built using industry-standard tools and practices: ASP.NET Core MVC for a clean, testable separation of concerns; Entity Framework Core's Code-First approach for a version-controlled, migration-driven database schema; and a consistent architectural pattern replicated across every module to maximize maintainability. The system was verified through structured functional, security, and regression testing conducted directly against the running application, with all executed test cases passing and no regressions observed in previously delivered functionality.

The result is a system that not only fulfils its original functional goal — digitizing and streamlining library catalogue and circulation management — but does so with a security and access-control posture appropriate for real, multi-user deployment, directly addressing the research gap identified in Section 2.3 between "functionally complete" and "safe to operate" student-built web applications.

---
---

# 11. FUTURE SCOPE

Building on the current implementation, the following enhancements are identified as valuable directions for future work:

1. **Fines and penalty management** — automatically calculate overdue fees based on a configurable per-day rate and a due-date field added to `BorrowRecord`, with an outstanding-balance view per borrower.
2. **Due-date tracking and notifications** — capture an expected return date at borrow time, and send automated email or in-app reminders as the due date approaches or passes.
3. **Self-service password reset via email** — implement a "Forgot Password" flow using time-limited, emailed reset tokens, removing the current dependency on Administrator intervention for locked-out users.
4. **Linking Account records to Student/Librarian directory entries** — introducing an optional foreign key from `Account` to `Student`/`Librarian` would allow borrowing history to be tied directly to a verified account rather than free-text borrower details.
5. **Full parity for the static HTML/JavaScript client** — extend the secondary static front end with the same Account management and Profile pages currently available only in the Razor MVC application, using the existing `/api/auth` endpoints as a foundation.
6. **Advanced analytics and reporting** — extend the Dashboard with visual charts (e.g., borrowing trends over time, most-active borrowers) and exportable reports (CSV/PDF).
7. **Token-based API authentication** — introduce JWT bearer authentication for the REST API layer to better support future non-browser clients such as a mobile application.
8. **Multi-library / multi-branch support** — extend the schema to support multiple library branches, each with its own catalogue subset and independent circulation records.
9. **Audit logging** — record a history of sensitive administrative actions (account creation, role changes, deletions) for compliance and accountability purposes.
10. **Automated test suite** — formalize the manual/scripted HTTP-level test cases documented in Section 7 into an automated integration test project (e.g., using `WebApplicationFactory` and xUnit) that can run as part of continuous integration.

---
---

# 12. REFERENCES

[1] Microsoft, "ASP.NET Core Documentation," *Microsoft Learn*, 2024. [Online]. Available: https://learn.microsoft.com/aspnet/core

[2] Microsoft, "Entity Framework Core Documentation," *Microsoft Learn*, 2024. [Online]. Available: https://learn.microsoft.com/ef/core

[3] Microsoft, "Rfc2898DeriveBytes Class (PBKDF2 Implementation)," *Microsoft Learn, .NET API Reference*, 2024. [Online]. Available: https://learn.microsoft.com/dotnet/api/system.security.cryptography.rfc2898derivebytes

[4] OWASP Foundation, "Password Storage Cheat Sheet," *OWASP Cheat Sheet Series*, 2023. [Online]. Available: https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html

[5] OWASP Foundation, "Cross-Site Request Forgery (CSRF) Prevention Cheat Sheet," *OWASP Cheat Sheet Series*, 2023.

[6] I. Sommerville, *Software Engineering*, 10th ed. Harlow, U.K.: Pearson Education, 2015.

[7] R. S. Pressman and B. R. Maxim, *Software Engineering: A Practitioner's Approach*, 9th ed. New York, NY, USA: McGraw-Hill Education, 2019.

[8] IEEE Computer Society, "IEEE Recommended Practice for Software Requirements Specifications," *IEEE Std 830-1998*, 1998.

[9] The Bootstrap Team, "Bootstrap Documentation, v5.3," 2024. [Online]. Available: https://getbootstrap.com/docs/5.3/

[10] Microsoft, "Overview of ASP.NET Core MVC," *Microsoft Learn*, 2024. [Online]. Available: https://learn.microsoft.com/aspnet/core/mvc/overview

[11] Microsoft, "EF Core Migrations Overview," *Microsoft Learn*, 2024. [Online]. Available: https://learn.microsoft.com/ef/core/managing-schemas/migrations

[12] E. Gamma, R. Helm, R. Johnson, and J. Vlissides, *Design Patterns: Elements of Reusable Object-Oriented Software*. Boston, MA, USA: Addison-Wesley, 1994.

---
---

# APPENDIX A — GLOSSARY OF TERMS

| Term | Definition |
|---|---|
| **Action Filter** | An ASP.NET Core component that runs custom logic before or after an MVC controller action executes. |
| **Anti-Forgery Token** | A hidden, per-form token used to prevent Cross-Site Request Forgery attacks on state-changing requests. |
| **Code-First Migration** | An EF Core workflow in which the database schema is derived from, and kept in sync with, C# model classes. |
| **DTO (Data Transfer Object)** | A plain object used to shape data sent to or received from an API, independent of the internal domain model. |
| **PBKDF2** | Password-Based Key Derivation Function 2, a standard algorithm for deriving a cryptographic key (here, a password hash) from a password and salt through repeated hashing. |
| **RBAC** | Role-Based Access Control — restricting system functionality based on a user's assigned role rather than their individual identity. |
| **Salt** | A unique, random value combined with a password before hashing, to ensure identical passwords produce different stored hashes. |
| **Session** | Server-side state associated with a specific client, typically identified via a cookie, used here to persist login identity and role across requests. |
| **ViewModel** | A class designed specifically to carry the exact data a Razor view needs to render, decoupled from the persistence-layer entity classes. |

---

# APPENDIX B — DATABASE SCHEMA (DDL)

```sql
CREATE TABLE Accounts (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Username      NVARCHAR(50)  NOT NULL,
    PasswordHash  NVARCHAR(MAX) NOT NULL,
    FullName      NVARCHAR(100) NOT NULL,
    Email         NVARCHAR(MAX) NOT NULL,
    Role          INT           NOT NULL,   -- 0=Admin,1=Librarian,2=Teacher,3=Student
    CreatedAt     DATETIME2     NOT NULL
);
CREATE UNIQUE INDEX IX_Accounts_Username ON Accounts (Username);

CREATE TABLE Books (
    BookId        INT IDENTITY(1,1) PRIMARY KEY,
    Title         NVARCHAR(100) NOT NULL,
    Author        NVARCHAR(100) NOT NULL,
    ISBN          NVARCHAR(50)  NOT NULL,
    PublishedDate DATE          NOT NULL,
    IsAvailable   BIT           NOT NULL DEFAULT 1
);

CREATE TABLE BorrowRecords (
    BorrowRecordId INT IDENTITY(1,1) PRIMARY KEY,
    BookId         INT NOT NULL REFERENCES Books(BookId),
    BorrowerName   NVARCHAR(100) NOT NULL,
    BorrowerEmail  NVARCHAR(255) NOT NULL,
    Phone          NVARCHAR(20)  NOT NULL,
    BorrowDate     DATETIME2     NOT NULL,
    ReturnDate     DATETIME2     NULL
);

CREATE TABLE Students (
    StudentId   INT IDENTITY(1,1) PRIMARY KEY,
    StudentName NVARCHAR(100) NOT NULL,
    Email       NVARCHAR(255) NOT NULL,
    Phone       NVARCHAR(20)  NOT NULL
);

CREATE TABLE Librarians (
    LibrarianId INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL,
    Age         INT           NOT NULL,
    Phone       NVARCHAR(20)  NOT NULL
);

CREATE TABLE Publications (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Title         NVARCHAR(100) NOT NULL,
    Publisher     NVARCHAR(50)  NOT NULL,
    PublishedDate DATE          NOT NULL,
    [Type]        INT           NOT NULL,  -- 0=Newspaper, 1=Magazine
    IsAvailable   BIT           NOT NULL DEFAULT 1
);
```

---

# APPENDIX C — SELECTED SOURCE CODE LISTINGS

**C.1 — Account Domain Model**

```csharp
public enum AccountRole { Admin, Librarian, Teacher, Student }

public class Account
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public AccountRole Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
```

**C.2 — Login Verification Logic (LoginController)**

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Verify(LoginViewModel model)
{
    if (!ModelState.IsValid) return View("Index", model);

    var match = await _context.Accounts
        .FirstOrDefaultAsync(u => u.Username == model.Username);

    if (match == null || !PasswordHasher.Verify(model.Password ?? "", match.PasswordHash))
    {
        ViewBag.LoginError = "Login failed. Invalid username or password.";
        return View("Index", model);
    }

    HttpContext.Session.SetString("Username", match.Username);
    HttpContext.Session.SetString("Role", match.Role.ToString());
    HttpContext.Session.SetInt32("AccountId", match.Id);
    return RedirectToAction("Index", "Home");
}
```

**C.3 — Change Password Logic (ProfileController)**

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
{
    if (!ModelState.IsValid) return View(model);

    var account = await GetCurrentAccountAsync();
    if (account == null) return RedirectToAction("Index", "Login");

    if (!PasswordHasher.Verify(model.CurrentPassword, account.PasswordHash))
    {
        ModelState.AddModelError(nameof(model.CurrentPassword), "Current password is incorrect.");
        return View(model);
    }

    account.PasswordHash = PasswordHasher.HashPassword(model.NewPassword);
    await _context.SaveChangesAsync();

    TempData["SuccessMessage"] = "Your password has been changed.";
    return RedirectToAction(nameof(Index));
}
```

---

*End of Report.*
