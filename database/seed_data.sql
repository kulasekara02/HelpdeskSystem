-- ============================================================================
-- HELPDESK TICKET SYSTEM - Seed Data for Oracle 19c
-- ============================================================================
-- NOTE: This script assumes Identity tables have been created and seeded
-- by the application. The user IDs below are placeholders.
-- Run the application first to create users, then update the IDs here
-- if you want to insert data directly via SQL.
-- ============================================================================

-- ============================================================================
-- SAMPLE USER IDs (Replace with actual IDs after running the application)
-- ============================================================================
-- These are placeholder GUIDs. The application will create actual users.
-- Admin:  admin-id-placeholder
-- Agent1: agent1-id-placeholder
-- Agent2: agent2-id-placeholder
-- Agent3: agent3-id-placeholder
-- Agent4: agent4-id-placeholder
-- Agent5: agent5-id-placeholder
-- User1:  user1-id-placeholder
-- User2:  user2-id-placeholder
-- User3:  user3-id-placeholder
-- User4:  user4-id-placeholder
-- User5:  user5-id-placeholder

-- ============================================================================
-- TICKETS (20 tickets with realistic data)
-- ============================================================================

-- Ticket 1
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000001', 'Cannot login to the system',
        'I have been trying to login for the past hour but keep getting an "Invalid credentials" error. I am sure my password is correct. Please help urgently as I have important work to complete.',
        'High', 'InProgress', SYSTIMESTAMP - INTERVAL '13' DAY, SYSTIMESTAMP - INTERVAL '12' DAY,
        'user1-id-placeholder', 'agent1-id-placeholder');

-- Ticket 2
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000002', 'Email not syncing properly',
        'My Outlook is not syncing with the server. I can see emails on my phone but they dont appear on the desktop client. This started happening after the last Windows update.',
        'Medium', 'Open', SYSTIMESTAMP - INTERVAL '12' DAY, NULL,
        'user2-id-placeholder', NULL);

-- Ticket 3
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000003', 'Password reset not working',
        'When I click on the forgot password link, I receive the reset email but the link inside the email gives me a 404 error. I have tried multiple times.',
        'High', 'Resolved', SYSTIMESTAMP - INTERVAL '11' DAY, SYSTIMESTAMP - INTERVAL '9' DAY,
        'user3-id-placeholder', 'agent2-id-placeholder');

-- Ticket 4
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000004', 'Application crashes on startup',
        'The CRM application crashes immediately after launch. I see a blue screen for a moment and then the application closes. No error message is displayed.',
        'High', 'InProgress', SYSTIMESTAMP - INTERVAL '10' DAY, SYSTIMESTAMP - INTERVAL '9' DAY,
        'user1-id-placeholder', 'agent3-id-placeholder');

-- Ticket 5
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000005', 'Need access to shared drive',
        'I am a new employee in the Marketing department and I need access to the shared drive where all the campaign materials are stored. My manager approved this request.',
        'Low', 'Closed', SYSTIMESTAMP - INTERVAL '10' DAY, SYSTIMESTAMP - INTERVAL '8' DAY,
        'user4-id-placeholder', 'agent1-id-placeholder');

-- Ticket 6
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000006', 'Printer not responding',
        'The HP printer on 3rd floor near the break room is not printing. It shows online but jobs get stuck in the queue. Already tried restarting it.',
        'Medium', 'Open', SYSTIMESTAMP - INTERVAL '9' DAY, NULL,
        'user5-id-placeholder', 'agent4-id-placeholder');

-- Ticket 7
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000007', 'VPN connection issues',
        'When working from home, the VPN keeps disconnecting every 30 minutes. This is very disruptive as I lose connection to all internal systems.',
        'High', 'InProgress', SYSTIMESTAMP - INTERVAL '8' DAY, SYSTIMESTAMP - INTERVAL '7' DAY,
        'user2-id-placeholder', 'agent5-id-placeholder');

-- Ticket 8
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000008', 'Software installation request',
        'I need Adobe Photoshop installed on my workstation for the new design project. This has been approved by my department head.',
        'Low', 'Resolved', SYSTIMESTAMP - INTERVAL '8' DAY, SYSTIMESTAMP - INTERVAL '6' DAY,
        'user3-id-placeholder', 'agent1-id-placeholder');

-- Ticket 9
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000009', 'Slow computer performance',
        'My laptop has become extremely slow over the past week. Applications take forever to open and sometimes the system freezes completely.',
        'Medium', 'Open', SYSTIMESTAMP - INTERVAL '7' DAY, NULL,
        'user4-id-placeholder', NULL);

-- Ticket 10
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000010', 'Monitor display flickering',
        'My secondary monitor started flickering yesterday. The primary monitor works fine. Already checked the cable connections.',
        'Low', 'Closed', SYSTIMESTAMP - INTERVAL '7' DAY, SYSTIMESTAMP - INTERVAL '5' DAY,
        'user5-id-placeholder', 'agent2-id-placeholder');

-- Ticket 11
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000011', 'Keyboard not functioning',
        'Some keys on my keyboard have stopped working. The letters Q, W, and E do not register when pressed. Need a replacement keyboard.',
        'Medium', 'Resolved', SYSTIMESTAMP - INTERVAL '6' DAY, SYSTIMESTAMP - INTERVAL '4' DAY,
        'user1-id-placeholder', 'agent3-id-placeholder');

-- Ticket 12
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000012', 'Mouse scroll not working',
        'The scroll wheel on my mouse has stopped working. I can still click but cannot scroll. It is a wireless Logitech mouse.',
        'Low', 'Open', SYSTIMESTAMP - INTERVAL '6' DAY, NULL,
        'user2-id-placeholder', NULL);

-- Ticket 13
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000013', 'File recovery needed',
        'I accidentally deleted an important Excel file from my Documents folder. The file was called Q4_Budget_Final.xlsx. Can it be recovered from backup?',
        'High', 'Resolved', SYSTIMESTAMP - INTERVAL '5' DAY, SYSTIMESTAMP - INTERVAL '4' DAY,
        'user3-id-placeholder', 'agent4-id-placeholder');

-- Ticket 14
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000014', 'Network connectivity problem',
        'My computer loses network connection intermittently. It works fine for a few hours and then suddenly disconnects. Have to restart to get it back.',
        'High', 'InProgress', SYSTIMESTAMP - INTERVAL '5' DAY, SYSTIMESTAMP - INTERVAL '4' DAY,
        'user4-id-placeholder', 'agent5-id-placeholder');

-- Ticket 15
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000015', 'Browser keeps freezing',
        'Chrome browser freezes frequently when I have multiple tabs open. Sometimes the entire computer becomes unresponsive.',
        'Medium', 'Open', SYSTIMESTAMP - INTERVAL '4' DAY, NULL,
        'user5-id-placeholder', 'agent1-id-placeholder');

-- Ticket 16
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000016', 'Audio not working in meetings',
        'When I join video meetings, others cannot hear me even though my microphone is selected. Works fine for regular audio playback.',
        'Medium', 'Resolved', SYSTIMESTAMP - INTERVAL '4' DAY, SYSTIMESTAMP - INTERVAL '2' DAY,
        'user1-id-placeholder', 'agent2-id-placeholder');

-- Ticket 17
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000017', 'Webcam quality issues',
        'My webcam shows a very blurry image during video calls. I cleaned the lens but it did not help. The camera is built into my laptop.',
        'Low', 'Open', SYSTIMESTAMP - INTERVAL '3' DAY, NULL,
        'user2-id-placeholder', NULL);

-- Ticket 18
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000018', 'System update failure',
        'Windows update keeps failing with error code 0x80070002. I have tried the troubleshooter but it did not fix the issue.',
        'Medium', 'InProgress', SYSTIMESTAMP - INTERVAL '3' DAY, SYSTIMESTAMP - INTERVAL '2' DAY,
        'user3-id-placeholder', 'agent3-id-placeholder');

-- Ticket 19
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000019', 'Database connection error',
        'The inventory management application shows "Database connection failed" error. This affects the entire warehouse team.',
        'High', 'Open', SYSTIMESTAMP - INTERVAL '2' DAY, NULL,
        'user4-id-placeholder', 'agent4-id-placeholder');

-- Ticket 20
INSERT INTO TICKETS (TICKETID, TITLE, DESCRIPTION, PRIORITY, STATUS, CREATEDAT, UPDATEDAT, CREATEDBYUSERID, ASSIGNEDAGENTID)
VALUES ('t0000001-0001-0001-0001-000000000020', 'Report generation taking too long',
        'The monthly sales report used to take 2 minutes to generate but now takes over 30 minutes. Database might need optimization.',
        'Medium', 'Open', SYSTIMESTAMP - INTERVAL '1' DAY, NULL,
        'user5-id-placeholder', NULL);

-- ============================================================================
-- COMMENTS (40+ comments across tickets)
-- ============================================================================

-- Comments for Ticket 1
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000001', 't0000001-0001-0001-0001-000000000001',
        'Thank you for reporting this issue. I am looking into it now and will check the authentication logs.',
        SYSTIMESTAMP - INTERVAL '12' DAY + INTERVAL '2' HOUR, 'agent1-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000002', 't0000001-0001-0001-0001-000000000001',
        'Found the issue - your account was locked due to multiple failed attempts. I have unlocked it. Please try logging in again.',
        SYSTIMESTAMP - INTERVAL '12' DAY + INTERVAL '4' HOUR, 'agent1-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000003', 't0000001-0001-0001-0001-000000000001',
        'I can log in now. Thank you for the quick response!',
        SYSTIMESTAMP - INTERVAL '12' DAY + INTERVAL '5' HOUR, 'user1-id-placeholder');

-- Comments for Ticket 2
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000004', 't0000001-0001-0001-0001-000000000002',
        'Have you tried removing and re-adding your email account in Outlook? Sometimes this fixes sync issues.',
        SYSTIMESTAMP - INTERVAL '11' DAY, 'agent2-id-placeholder');

-- Comments for Ticket 3
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000005', 't0000001-0001-0001-0001-000000000003',
        'I have identified a bug in our password reset link generation. Working on a fix now.',
        SYSTIMESTAMP - INTERVAL '10' DAY, 'agent2-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000006', 't0000001-0001-0001-0001-000000000003',
        'The fix has been deployed. Could you please try the password reset again?',
        SYSTIMESTAMP - INTERVAL '9' DAY + INTERVAL '6' HOUR, 'agent2-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000007', 't0000001-0001-0001-0001-000000000003',
        'It works now! Password reset successfully. Thank you!',
        SYSTIMESTAMP - INTERVAL '9' DAY + INTERVAL '8' HOUR, 'user3-id-placeholder');

-- Comments for Ticket 4
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000008', 't0000001-0001-0001-0001-000000000004',
        'This sounds like a graphics driver issue. I will need to remote into your machine to investigate.',
        SYSTIMESTAMP - INTERVAL '9' DAY + INTERVAL '3' HOUR, 'agent3-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000009', 't0000001-0001-0001-0001-000000000004',
        'Sure, I am available now if you want to connect.',
        SYSTIMESTAMP - INTERVAL '9' DAY + INTERVAL '4' HOUR, 'user1-id-placeholder');

-- Comments for Ticket 5
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000010', 't0000001-0001-0001-0001-000000000005',
        'Access granted. You should be able to see the Marketing shared drive now. Welcome to the team!',
        SYSTIMESTAMP - INTERVAL '8' DAY, 'agent1-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000011', 't0000001-0001-0001-0001-000000000005',
        'I can see the drive now. Thanks for the quick help!',
        SYSTIMESTAMP - INTERVAL '8' DAY + INTERVAL '1' HOUR, 'user4-id-placeholder');

-- Comments for Ticket 6
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000012', 't0000001-0001-0001-0001-000000000006',
        'I have scheduled a technician to look at the printer tomorrow morning.',
        SYSTIMESTAMP - INTERVAL '8' DAY + INTERVAL '4' HOUR, 'agent4-id-placeholder');

-- Comments for Ticket 7
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000013', 't0000001-0001-0001-0001-000000000007',
        'Can you check if you have the latest VPN client installed? The current version is 5.2.1.',
        SYSTIMESTAMP - INTERVAL '7' DAY + INTERVAL '2' HOUR, 'agent5-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000014', 't0000001-0001-0001-0001-000000000007',
        'I have version 5.1.3. Let me update and try again.',
        SYSTIMESTAMP - INTERVAL '7' DAY + INTERVAL '3' HOUR, 'user2-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000015', 't0000001-0001-0001-0001-000000000007',
        'Upgraded to 5.2.1 but still having the same issue.',
        SYSTIMESTAMP - INTERVAL '7' DAY + INTERVAL '5' HOUR, 'user2-id-placeholder');

-- Comments for Ticket 8
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000016', 't0000001-0001-0001-0001-000000000008',
        'Adobe Photoshop has been installed on your workstation. Please restart your computer and it should appear in your programs.',
        SYSTIMESTAMP - INTERVAL '6' DAY, 'agent1-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000017', 't0000001-0001-0001-0001-000000000008',
        'Perfect, I can see Photoshop now. Thank you!',
        SYSTIMESTAMP - INTERVAL '6' DAY + INTERVAL '2' HOUR, 'user3-id-placeholder');

-- Comments for Ticket 9
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000018', 't0000001-0001-0001-0001-000000000009',
        'How much free space do you have on your hard drive? Also, when was the last time you restarted your computer?',
        SYSTIMESTAMP - INTERVAL '6' DAY + INTERVAL '4' HOUR, 'agent2-id-placeholder');

-- Comments for Ticket 10
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000019', 't0000001-0001-0001-0001-000000000010',
        'The issue was with the display cable. I have replaced it and the monitor is working properly now.',
        SYSTIMESTAMP - INTERVAL '5' DAY, 'agent2-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000020', 't0000001-0001-0001-0001-000000000010',
        'Confirmed, no more flickering. Thanks!',
        SYSTIMESTAMP - INTERVAL '5' DAY + INTERVAL '1' HOUR, 'user5-id-placeholder');

-- Comments for Ticket 11
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000021', 't0000001-0001-0001-0001-000000000011',
        'A new keyboard has been ordered and will arrive tomorrow.',
        SYSTIMESTAMP - INTERVAL '5' DAY + INTERVAL '3' HOUR, 'agent3-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000022', 't0000001-0001-0001-0001-000000000011',
        'New keyboard installed and working perfectly. Thank you for the quick replacement!',
        SYSTIMESTAMP - INTERVAL '4' DAY, 'user1-id-placeholder');

-- Comments for Ticket 13
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000023', 't0000001-0001-0001-0001-000000000013',
        'Good news - I found the file in our backup system from yesterday. Restoring it now.',
        SYSTIMESTAMP - INTERVAL '4' DAY + INTERVAL '4' HOUR, 'agent4-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000024', 't0000001-0001-0001-0001-000000000013',
        'File has been restored to your Documents folder.',
        SYSTIMESTAMP - INTERVAL '4' DAY + INTERVAL '5' HOUR, 'agent4-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000025', 't0000001-0001-0001-0001-000000000013',
        'You are a lifesaver! Found the file. Thank you so much!',
        SYSTIMESTAMP - INTERVAL '4' DAY + INTERVAL '6' HOUR, 'user3-id-placeholder');

-- Comments for Ticket 14
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000026', 't0000001-0001-0001-0001-000000000014',
        'I suspect this might be a faulty network card. Let me run some diagnostics.',
        SYSTIMESTAMP - INTERVAL '4' DAY + INTERVAL '2' HOUR, 'agent5-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000027', 't0000001-0001-0001-0001-000000000014',
        'Diagnostics complete. The network adapter driver needs to be updated. Working on it.',
        SYSTIMESTAMP - INTERVAL '4' DAY + INTERVAL '4' HOUR, 'agent5-id-placeholder');

-- Comments for Ticket 15
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000028', 't0000001-0001-0001-0001-000000000015',
        'How much RAM does your computer have? Chrome can be quite memory-hungry with multiple tabs.',
        SYSTIMESTAMP - INTERVAL '3' DAY + INTERVAL '5' HOUR, 'agent1-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000029', 't0000001-0001-0001-0001-000000000015',
        'I have 8GB RAM. Usually I have about 15-20 tabs open.',
        SYSTIMESTAMP - INTERVAL '3' DAY + INTERVAL '6' HOUR, 'user5-id-placeholder');

-- Comments for Ticket 16
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000030', 't0000001-0001-0001-0001-000000000016',
        'Please check if the correct microphone is selected in your meeting app settings.',
        SYSTIMESTAMP - INTERVAL '3' DAY, 'agent2-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000031', 't0000001-0001-0001-0001-000000000016',
        'The microphone was muted in Windows sound settings. Fixed it now and audio works!',
        SYSTIMESTAMP - INTERVAL '2' DAY, 'user1-id-placeholder');

-- Comments for Ticket 17
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000032', 't0000001-0001-0001-0001-000000000017',
        'This could be a driver issue or the camera might be physically damaged. When did this start?',
        SYSTIMESTAMP - INTERVAL '2' DAY + INTERVAL '3' HOUR, 'agent3-id-placeholder');

-- Comments for Ticket 18
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000033', 't0000001-0001-0001-0001-000000000018',
        'This error usually occurs when Windows Update components are corrupted. I will run the DISM tool to repair them.',
        SYSTIMESTAMP - INTERVAL '2' DAY + INTERVAL '2' HOUR, 'agent3-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000034', 't0000001-0001-0001-0001-000000000018',
        'DISM repair completed. Please try running Windows Update again.',
        SYSTIMESTAMP - INTERVAL '2' DAY + INTERVAL '4' HOUR, 'agent3-id-placeholder');

-- Comments for Ticket 19
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000035', 't0000001-0001-0001-0001-000000000019',
        'This is a critical issue. I am escalating to the database team immediately.',
        SYSTIMESTAMP - INTERVAL '1' DAY + INTERVAL '8' HOUR, 'agent4-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000036', 't0000001-0001-0001-0001-000000000019',
        'The database server ran out of connection pool. We are restarting the service now.',
        SYSTIMESTAMP - INTERVAL '1' DAY + INTERVAL '10' HOUR, 'agent4-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000037', 't0000001-0001-0001-0001-000000000019',
        'Still seeing the error. Is the fix applied yet?',
        SYSTIMESTAMP - INTERVAL '1' DAY + INTERVAL '11' HOUR, 'user4-id-placeholder');

-- Comments for Ticket 20
INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000038', 't0000001-0001-0001-0001-000000000020',
        'This does sound like a database optimization issue. Can you tell me which specific report is slow?',
        SYSTIMESTAMP - INTERVAL '12' HOUR, 'agent5-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000039', 't0000001-0001-0001-0001-000000000020',
        'It is the Monthly Sales Summary report. Used to be fast but slowed down after we added the new product categories.',
        SYSTIMESTAMP - INTERVAL '10' HOUR, 'user5-id-placeholder');

INSERT INTO COMMENTS (COMMENTID, TICKETID, TEXT, CREATEDAT, CREATEDBYUSERID)
VALUES ('c0000001-0001-0001-0001-000000000040', 't0000001-0001-0001-0001-000000000020',
        'I will analyze the query execution plan and add appropriate indexes. Will update you shortly.',
        SYSTIMESTAMP - INTERVAL '8' HOUR, 'agent5-id-placeholder');

-- ============================================================================
-- STATUS HISTORY (tracking changes)
-- ============================================================================

-- Status history for Ticket 1
INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000001', 't0000001-0001-0001-0001-000000000001',
        NULL, 'Open', SYSTIMESTAMP - INTERVAL '13' DAY, 'user1-id-placeholder');

INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000002', 't0000001-0001-0001-0001-000000000001',
        'Open', 'InProgress', SYSTIMESTAMP - INTERVAL '12' DAY, 'agent1-id-placeholder');

-- Status history for Ticket 3
INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000003', 't0000001-0001-0001-0001-000000000003',
        NULL, 'Open', SYSTIMESTAMP - INTERVAL '11' DAY, 'user3-id-placeholder');

INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000004', 't0000001-0001-0001-0001-000000000003',
        'Open', 'InProgress', SYSTIMESTAMP - INTERVAL '10' DAY, 'agent2-id-placeholder');

INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000005', 't0000001-0001-0001-0001-000000000003',
        'InProgress', 'Resolved', SYSTIMESTAMP - INTERVAL '9' DAY, 'agent2-id-placeholder');

-- Status history for Ticket 5
INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000006', 't0000001-0001-0001-0001-000000000005',
        NULL, 'Open', SYSTIMESTAMP - INTERVAL '10' DAY, 'user4-id-placeholder');

INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000007', 't0000001-0001-0001-0001-000000000005',
        'Open', 'Resolved', SYSTIMESTAMP - INTERVAL '8' DAY + INTERVAL '2' HOUR, 'agent1-id-placeholder');

INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000008', 't0000001-0001-0001-0001-000000000005',
        'Resolved', 'Closed', SYSTIMESTAMP - INTERVAL '8' DAY, 'user4-id-placeholder');

-- Status history for Ticket 10
INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000009', 't0000001-0001-0001-0001-000000000010',
        NULL, 'Open', SYSTIMESTAMP - INTERVAL '7' DAY, 'user5-id-placeholder');

INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000010', 't0000001-0001-0001-0001-000000000010',
        'Open', 'Resolved', SYSTIMESTAMP - INTERVAL '5' DAY + INTERVAL '2' HOUR, 'agent2-id-placeholder');

INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000011', 't0000001-0001-0001-0001-000000000010',
        'Resolved', 'Closed', SYSTIMESTAMP - INTERVAL '5' DAY, 'user5-id-placeholder');

-- Additional status histories for other tickets (Open -> InProgress transitions)
INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000012', 't0000001-0001-0001-0001-000000000004',
        NULL, 'Open', SYSTIMESTAMP - INTERVAL '10' DAY, 'user1-id-placeholder');

INSERT INTO STATUSHISTORY (HISTORYID, TICKETID, OLDSTATUS, NEWSTATUS, CHANGEDAT, CHANGEDBYUSERID)
VALUES ('h0000001-0001-0001-0001-000000000013', 't0000001-0001-0001-0001-000000000004',
        'Open', 'InProgress', SYSTIMESTAMP - INTERVAL '9' DAY, 'agent3-id-placeholder');

-- Commit the transaction
COMMIT;

-- ============================================================================
-- VERIFICATION QUERIES
-- ============================================================================
-- SELECT COUNT(*) AS TICKET_COUNT FROM TICKETS;
-- SELECT COUNT(*) AS COMMENT_COUNT FROM COMMENTS;
-- SELECT COUNT(*) AS HISTORY_COUNT FROM STATUSHISTORY;
-- SELECT STATUS, COUNT(*) FROM TICKETS GROUP BY STATUS;
-- SELECT * FROM VW_DASHBOARD_STATS;
-- SELECT * FROM VW_TICKETS_PER_DAY;
