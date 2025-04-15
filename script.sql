CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Products" (
    "ProductId" uuid NOT NULL,
    "ProductName" text,
    "Category" text,
    "UnitPrice" double precision NOT NULL,
    "QuantityInStock" integer NOT NULL,
    CONSTRAINT "PK_Products" PRIMARY KEY ("ProductId")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250414144941_Initial', '8.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Products" ALTER COLUMN "UnitPrice" DROP NOT NULL;

ALTER TABLE "Products" ALTER COLUMN "QuantityInStock" DROP NOT NULL;

ALTER TABLE "Products" ALTER COLUMN "ProductName" TYPE varchar(30);
UPDATE "Products" SET "ProductName" = '' WHERE "ProductName" IS NULL;
ALTER TABLE "Products" ALTER COLUMN "ProductName" SET NOT NULL;
ALTER TABLE "Products" ALTER COLUMN "ProductName" SET DEFAULT '';

ALTER TABLE "Products" ALTER COLUMN "Category" TYPE varchar(30);
UPDATE "Products" SET "Category" = '' WHERE "Category" IS NULL;
ALTER TABLE "Products" ALTER COLUMN "Category" SET NOT NULL;
ALTER TABLE "Products" ALTER COLUMN "Category" SET DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250415090048_Add configuring for Products', '8.0.11');

COMMIT;

