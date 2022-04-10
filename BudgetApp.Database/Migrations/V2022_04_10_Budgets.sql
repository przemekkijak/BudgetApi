create table budgets
(
    id int,
    user_id int not null,
    create_date timestamp null,
    update_date timestamp null
);

create unique index budgets_id_uindex
    on budgets (id);

create index budgets_user_id_index
    on budgets (user_id);

alter table budgets
    add constraint budgets_pk
        primary key (id);

alter table budgets modify id int auto_increment;

