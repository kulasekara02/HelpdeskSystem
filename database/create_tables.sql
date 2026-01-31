-- ============================================================================
-- HELPDESK TICKET SYSTEM - Oracle Database Schema
-- Compatible with Oracle 19c
-- ============================================================================

-- ============================================================================
-- DROP EXISTING TABLES (if they exist) - Run this section only if needed
-- ============================================================================
-- BEGIN
--     EXECUTE IMMEDIATE 'DROP TABLE STATUSHISTORY CASCADE CONSTRAINTS';
-- EXCEPTION WHEN OTHERS THEN NULL;
-- END;
-- /
-- BEGIN
--     EXECUTE IMMEDIATE 'DROP TABLE COMMENTS CASCADE CONSTRAINTS';
-- EXCEPTION WHEN OTHERS THEN NULL;
-- END;
-- /
-- BEGIN
--     EXECUTE IMMEDIATE 'DROP TABLE TICKETS CASCADE CONSTRAINTS';
-- EXCEPTION WHEN OTHERS THEN NULL;
-- END;
-- /

-- ============================================================================
-- ASP.NET CORE IDENTITY TABLES
-- These are created automatically by EF Core migrations
-- ============================================================================

-- Note: The following Identity tables are created by EF Core:
-- - ASPNETUSERS
-- - ASPNETROLES
-- - ASPNETUSERCLAIMS
-- - ASPNETUSERLOGINS
-- - ASPNETUSERROLES
-- - ASPNETUSERTOKENS
-- - ASPNETROLECLAIMS

-- ============================================================================
-- TICKETS TABLE
-- ============================================================================
CREATE TABLE TICKETS (
    TICKETID            CHAR(36)        NOT NULL,
    TITLE               VARCHAR2(200)   NOT NULL,
    DESCRIPTION         CLOB            NOT NULL,
    PRIORITY            VARCHAR2(20)    NOT NULL,
    STATUS              VARCHAR2(20)    NOT NULL,
    CREATEDAT           TIMESTAMP       NOT NULL,
    UPDATEDAT           TIMESTAMP       NULL,
    CREATEDBYUSERID     VARCHAR2(450)   NOT NULL,
    ASSIGNEDAGENTID     VARCHAR2(450)   NULL,
    CONSTRAINT PK_TICKETS PRIMARY KEY (TICKETID),
    CONSTRAINT CK_TICKETS_PRIORITY CHECK (PRIORITY IN ('Low', 'Medium', 'High')),
    CONSTRAINT CK_TICKETS_STATUS CHECK (STATUS IN ('Open', 'InProgress', 'Resolved', 'Closed'))
);

-- Add foreign key constraints after Identity tables are created
-- CONSTRAINT FK_TICKETS_CREATEDBY FOREIGN KEY (CREATEDBYUSERID) REFERENCES ASPNETUSERS(ID),
-- CONSTRAINT FK_TICKETS_AGENT FOREIGN KEY (ASSIGNEDAGENTID) REFERENCES ASPNETUSERS(ID)

-- Indexes for TICKETS table
CREATE INDEX IX_TICKETS_STATUS ON TICKETS(STATUS);
CREATE INDEX IX_TICKETS_PRIORITY ON TICKETS(PRIORITY);
CREATE INDEX IX_TICKETS_CREATEDAT ON TICKETS(CREATEDAT);
CREATE INDEX IX_TICKETS_ASSIGNEDAGENTID ON TICKETS(ASSIGNEDAGENTID);
CREATE INDEX IX_TICKETS_CREATEDBYUSERID ON TICKETS(CREATEDBYUSERID);

-- ============================================================================
-- COMMENTS TABLE
-- ============================================================================
CREATE TABLE COMMENTS (
    COMMENTID           CHAR(36)        NOT NULL,
    TICKETID            CHAR(36)        NOT NULL,
    TEXT                CLOB            NOT NULL,
    CREATEDAT           TIMESTAMP       NOT NULL,
    CREATEDBYUSERID     VARCHAR2(450)   NOT NULL,
    CONSTRAINT PK_COMMENTS PRIMARY KEY (COMMENTID),
    CONSTRAINT FK_COMMENTS_TICKET FOREIGN KEY (TICKETID) REFERENCES TICKETS(TICKETID) ON DELETE CASCADE
);

-- Indexes for COMMENTS table
CREATE INDEX IX_COMMENTS_TICKETID ON COMMENTS(TICKETID);
CREATE INDEX IX_COMMENTS_CREATEDAT ON COMMENTS(CREATEDAT);

-- ============================================================================
-- STATUS HISTORY TABLE
-- ============================================================================
CREATE TABLE STATUSHISTORY (
    HISTORYID           CHAR(36)        NOT NULL,
    TICKETID            CHAR(36)        NOT NULL,
    OLDSTATUS           VARCHAR2(20)    NULL,
    NEWSTATUS           VARCHAR2(20)    NOT NULL,
    CHANGEDAT           TIMESTAMP       NOT NULL,
    CHANGEDBYUSERID     VARCHAR2(450)   NOT NULL,
    CONSTRAINT PK_STATUSHISTORY PRIMARY KEY (HISTORYID),
    CONSTRAINT FK_STATUSHISTORY_TICKET FOREIGN KEY (TICKETID) REFERENCES TICKETS(TICKETID) ON DELETE CASCADE,
    CONSTRAINT CK_STATUSHISTORY_OLD CHECK (OLDSTATUS IS NULL OR OLDSTATUS IN ('Open', 'InProgress', 'Resolved', 'Closed')),
    CONSTRAINT CK_STATUSHISTORY_NEW CHECK (NEWSTATUS IN ('Open', 'InProgress', 'Resolved', 'Closed'))
);

-- Indexes for STATUSHISTORY table
CREATE INDEX IX_STATUSHISTORY_TICKETID ON STATUSHISTORY(TICKETID);
CREATE INDEX IX_STATUSHISTORY_CHANGEDAT ON STATUSHISTORY(CHANGEDAT);

-- ============================================================================
-- USEFUL VIEWS (Optional)
-- ============================================================================

-- View: Tickets with user names
CREATE OR REPLACE VIEW VW_TICKETS_FULL AS
SELECT
    t.TICKETID,
    t.TITLE,
    t.DESCRIPTION,
    t.PRIORITY,
    t.STATUS,
    t.CREATEDAT,
    t.UPDATEDAT,
    t.CREATEDBYUSERID,
    t.ASSIGNEDAGENTID,
    (SELECT COUNT(*) FROM COMMENTS c WHERE c.TICKETID = t.TICKETID) AS COMMENTCOUNT
FROM TICKETS t;

-- View: Dashboard statistics
CREATE OR REPLACE VIEW VW_DASHBOARD_STATS AS
SELECT
    COUNT(*) AS TOTALTICKETS,
    SUM(CASE WHEN STATUS = 'Open' THEN 1 ELSE 0 END) AS OPENTICKETS,
    SUM(CASE WHEN STATUS = 'InProgress' THEN 1 ELSE 0 END) AS INPROGRESSTICKETS,
    SUM(CASE WHEN STATUS = 'Resolved' THEN 1 ELSE 0 END) AS RESOLVEDTICKETS,
    SUM(CASE WHEN STATUS = 'Closed' THEN 1 ELSE 0 END) AS CLOSEDTICKETS
FROM TICKETS;

-- View: Tickets created per day (last 14 days)
CREATE OR REPLACE VIEW VW_TICKETS_PER_DAY AS
SELECT
    TRUNC(CREATEDAT) AS TICKETDATE,
    COUNT(*) AS TICKETCOUNT
FROM TICKETS
WHERE CREATEDAT >= TRUNC(SYSDATE) - 14
GROUP BY TRUNC(CREATEDAT)
ORDER BY TRUNC(CREATEDAT);

-- ============================================================================
-- GRANT STATEMENTS (if needed for other users)
-- ============================================================================
-- GRANT SELECT, INSERT, UPDATE, DELETE ON TICKETS TO your_app_user;
-- GRANT SELECT, INSERT, UPDATE, DELETE ON COMMENTS TO your_app_user;
-- GRANT SELECT, INSERT, UPDATE, DELETE ON STATUSHISTORY TO your_app_user;

-- ============================================================================
-- END OF SCHEMA CREATION
-- ============================================================================
