﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addhotel_city : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Hotels",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Hotels");
        }
    }
}
