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
        itemType VARCHAR(255) COMMENT 'Type of item, e.g. weapon, armor, pendant',
        rune1 VARCHAR(255) DEFAULT "",
        rune2 VARCHAR(255) DEFAULT "",
        rune3 VARCHAR(255) DEFAULT "",
        rune4 VARCHAR(255) DEFAULT "",
        rune5 VARCHAR(255) DEFAULT "",
        rune6 VARCHAR(255) DEFAULT ""
    ) default charset utf8;

ALTER TABLE runewords
ADD
    COLUMN rune1 VARCHAR(255) DEFAULT "",
ADD
    COLUMN rune2 VARCHAR(255) DEFAULT "",
ADD
    COLUMN rune3 VARCHAR(255) DEFAULT "",
ADD
    COLUMN rune4 VARCHAR(255) DEFAULT "",
ADD
    COLUMN rune5 VARCHAR(255) DEFAULT "",
ADD
    COLUMN rune6 VARCHAR(255) DEFAULT "";

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
        name VARCHAR(255) NOT NULL primary key COMMENT ' primary key ',
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

CREATE TABLE
    IF NOT EXISTS effects (
        id INT NOT NULL primary key AUTO_INCREMENT COMMENT ' primary key ',
        name VARCHAR(255) NOT NULL,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        amount INT NOT NULL,
        isPercent BOOLEAN NOT NULL
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS effectstext (
        name VARCHAR(255) NOT NULL primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    '
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS skills (
        name VARCHAR(255) NOT NULL primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        description MEDIUMTEXT
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS runewordskills (
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        runewordId VARCHAR(255) NOT NULL,
        skillId VARCHAR(255) NOT NULL,
        FOREIGN KEY (runewordId) REFERENCES runewords(name) ON DELETE CASCADE,
        FOREIGN KEY (skillId) REFERENCES skills(name) ON DELETE CASCADE
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS runewordeffects (
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT ' primary key ',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT ' Time Created ',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT ' Last
Update
    ',
        runewordId VARCHAR(255) NOT NULL,
        effectId INT NOT NULL,
        FOREIGN KEY (runewordId) REFERENCES runewords(name) ON DELETE CASCADE,
        FOREIGN KEY (effectId) REFERENCES effects(id) ON DELETE CASCADE
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


SELECT runes.*, runewords.name AS runewordId
FROM runewords
RIGHT JOIN runes
ON runewords.rune1 = "xeo" OR runewords.rune2 = "xeo" OR runewords.rune3 = "xeo" OR runewords.rune4 = "xeo" OR runewords.rune5 = "xeo" OR runewords.rune6 = "xeo";