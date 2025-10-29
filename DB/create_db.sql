CREATE TABLE table_users (
    id uuid PRIMARY KEY,
    last_name TEXT NOT NULL CHECK ( last_name != '' ),
    first_name TEXT NOT NULL CHECK ( first_name != '' )
);

INSERT INTO table_users (id, last_name, first_name)
VALUES ('5dcb0627-ef5b-4f01-8b06-27ef5b3f0194', 'Doe', 'John'),
        ('133b8a95-bcd2-47fc-bb8a-95bcd2b7fcd9', 'Smith', 'Jane'),
        ('79b0ecbb-bd20-4aaf-b0ec-bbbd205aaf0a', 'Johnson', 'Mary');