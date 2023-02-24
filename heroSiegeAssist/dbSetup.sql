-- Active: 1672794515549@@72.24.148.117@3306@herosiege

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS runewords (
        name VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        itemSlot VARCHAR(255) COMMENT 'Slot item is worn in, e.g. helmet, boots, gloves',
        itemType VARCHAR(255) COMMENT 'Type of item, e.g. weapon, armor, pendant'
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS runes (
        name VARCHAR(255) NOT NULL primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        effect VARCHAR(255),
        tier VARCHAR(255),
        dropRate VARCHAR(255),
        img MEDIUMTEXT
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS possessedrunes (
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT ' primary key ',
        name VARCHAR(255) NOT NULL,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        effect VARCHAR(255),
        tier VARCHAR(255),
        dropRate VARCHAR(255),
        img MEDIUMTEXT,
        quantity INT NOT NULL DEFAULT 0,
        accountId VARCHAR(255) NOT NULL,
        FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8;

CREATE UNIQUE INDEX rune_account ON possessedrunes(name,accountId);

CREATE TABLE
    IF NOT EXISTS effectstext (
        name VARCHAR(255) NOT NULL primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    '
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS runewordabilities (
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        runewordId VARCHAR(255) NOT NULL,
        abilityId VARCHAR(255) NOT NULL,
        FOREIGN KEY (runewordId) REFERENCES runewords(name) ON DELETE CASCADE,
        FOREIGN KEY (abilityId) REFERENCES abilities(name) ON DELETE CASCADE
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS abilities (
        name VARCHAR(255) NOT NULL primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        description MEDIUMTEXT NOT NULL
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS items (
        name VARCHAR(255) NOT NULL primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        itemSlot VARCHAR(255),
        itemType VARCHAR(255)
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS runeworditems (
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update ',
        itemId VARCHAR(255) NOT NULL,
        runewordId VARCHAR(255) NOT NULL,
        FOREIGN KEY (itemId) REFERENCES items(name) ON DELETE CASCADE,
        FOREIGN KEY (runewordId) REFERENCES runewords(name) ON DELETE CASCADE
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS runewordeffects (
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        name VARCHAR(255) NOT NULL,
        runewordId VARCHAR(255) NOT NULL,
        FOREIGN KEY (runewordId) REFERENCES runewords(name) ON DELETE CASCADE
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS runerunewords (
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update ',
        runewordId VARCHAR(255) NOT NULL,
        runeId VARCHAR(255) NOT NULL,
        FOREIGN KEY (runewordId) REFERENCES runewords(name) ON DELETE CASCADE,
        FOREIGN KEY (runeId) REFERENCES runes(name) ON DELETE CASCADE
    ) default charset utf8;

SELECT
    runes.*,
    runewords.name AS runewordId
FROM runewords
    RIGHT JOIN runes ON runewords.rune1 = "xeo" OR runewords.rune2 = "xeo" OR runewords.rune3 = "xeo" OR runewords.rune4 = "xeo" OR runewords.rune5 = "xeo" OR runewords.rune6 = "xeo";

SELECT r.*
FROM runes r
    RIGHT JOIN runerunewords rrw ON rrw.runeId = r.name
WHERE
    rrw.runewordId = "scholar";

SELECT rw.name
FROM runewords rw
    RIGHT JOIN runerunewords rrw ON rrw.runewordId = rw.name
WHERE rrw.runeId = "qi";

SELECT DISTINCT acc.*
FROM possessedrunes pr
    JOIN accounts acc ON acc.id = pr.accountId;

DELETE FROM runewords;

SELECT DISTINCT rw.name
FROM runewords rw
    RIGHT JOIN runerunewords rrw ON rrw.runewordId = rw.name
WHERE rrw.runeId = "xeo";

SELECT rw.name
FROM runewords rw
    RIGHT JOIN runerunewords rrw ON rrw.runewordId = rw.name
WHERE rrw.runeId = "xeo";