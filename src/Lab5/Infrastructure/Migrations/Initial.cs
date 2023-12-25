using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        @"
        create type user_role as enum
        (
            'admin',
            'userbase'
        );

        create table users
        (
            user_id bigint primary key,
            user_name text not null,
            user_role user_role not null
        );

        create table accounts
        (
            account_id bigint primary key generated always as identity,
            account_name text not null,
            pin text not null,
            balance bigint not null 
        );

        create table transactions
        (
            transaction_id bigint primary key generated always as identity,
            account_id bigint not null,
            transaction_type text not null,
            amount bigint not null,
            date_time timestamp not null 
        );

        insert into accounts values (default, 'Admin', 'antihack', 0);
        ";

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        @"
        drop table users;
        drop table accounts;
        drop table transactions;
        drop type user_role;
        ";
}