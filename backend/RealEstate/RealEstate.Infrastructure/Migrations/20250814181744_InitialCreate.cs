using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    CarSpots = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "CarSpots", "City", "Description", "ImageUrl", "Price", "PropertyType", "Title" },
                values: new object[,]
                {
                    { new Guid("12b9a4b3-dfa0-4d19-bd66-7a0db144a523"), "Tower 5, Silicon Oasis", 1, 1, 0, "Dubai", "Affordable studio apartment in a vibrant tech hub area.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 42000.00m, "Rent", "Studio in Dubai Silicon Oasis" },
                    { new Guid("1eaa38c3-dc5a-4a16-b9d2-4a2b4b6a8b63"), "Gate Tower 2, DIFC", 2, 2, 1, "Dubai", "Stylish loft apartment in Dubai's financial district.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 175000.00m, "Rent", "Loft Apartment in DIFC" },
                    { new Guid("1f6694f2-845f-493a-9ba5-baa7115124cd"), "23 Palm View Rd", 4, 5, 2, "Dubai", "A stunning luxury villa with private pool, sea view, and modern interiors.", "https://images.unsplash.com/photo-1600607687939-ce8a6c25118c", 2500000.00m, "Sale", "Luxury Villa in Dubai Marina" },
                    { new Guid("2845462a-931a-4b94-9e9f-b861c2d39d83"), "Emirates Hills", 7, 7, 4, "Dubai", "Spacious villa with golf course view and luxury finishes.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 7800000.00m, "Sale", "Golf Course Villa" },
                    { new Guid("3b4df4c5-8400-48c2-88f6-d2572b7f76dc"), "12 Sheikh Zayed Rd", 2, 2, 1, "Dubai", "Modern 2-bedroom apartment close to metro station, with city skyline view.", "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2", 120000.00m, "Rent", "Modern Apartment Downtown" },
                    { new Guid("59ff22c0-38cb-4fd4-8c1b-f82a3d0d52d8"), "Palm Crescent West", 6, 6, 3, "Dubai", "Exclusive Palm Jumeirah villa with private beach access.", "https://images.unsplash.com/photo-1605276374104-dee2a0ed3cd6", 5200000.00m, "Sale", "Modern Villa in Palm Jumeirah" },
                    { new Guid("5f46e87d-1fc8-4d88-9345-dc44a2f63579"), "Cluster C, JLT", 1, 1, 1, "Dubai", "Fully furnished serviced apartment with lake view.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 130000.00m, "Rent", "Serviced Apartment in JLT" },
                    { new Guid("67175a89-5c65-4e41-854b-fc7ecbdf5f42"), "Dubai Marina Gate 3", 2, 2, 2, "Dubai", "Spacious apartment with marina view.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 10000.00m, "Rent", "Luxury Apartment in Marina City" },
                    { new Guid("84d7479d-872e-4d3b-9d16-553f20d7aa0a"), "22 Desert Bloom", 3, 3, 2, "Dubai", "Beautiful family townhouse with community pool and park access.", "https://images.unsplash.com/photo-1599423300746-b62533397364", 1600000.00m, "Sale", "Townhouse in Arabian Ranches" },
                    { new Guid("8f841f7e-a5f4-46b8-973d-8cf8b0f34f8b"), "99 Burj Khalifa Blvd", 4, 4, 2, "Dubai", "Luxury penthouse with panoramic views of the Dubai skyline and modern amenities.", "https://images.unsplash.com/photo-1600585154340-be6161a56a0c", 3500000.00m, "Sale", "Penthouse with Skyline View" },
                    { new Guid("9d0ccf94-bff3-4454-879a-6df93dc6f79a"), "Al Qudra Road", 4, 4, 2, "Dubai", "Elegant villa with expansive desert views and modern amenities.", "https://images.unsplash.com/photo-1600585154340-be6161a56a0c", 2200000.00m, "Sale", "Desert View Villa" },
                    { new Guid("a85af594-97fd-4b90-8cbf-6e6e9e8d7f8d"), "Dubai Marina Gate 2", 2, 2, 2, "Dubai", "Spacious apartment with marina view.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 20000.00m, "Rent", "Luxury Apartment in Marina City" },
                    { new Guid("b3db3af2-dc5a-4f1f-8a79-8fb9e6bcf156"), "101 Bay Square", 1, 1, 0, "Dubai", "Cozy studio apartment ideal for professionals, located in the heart of Business Bay.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 55000.00m, "Rent", "Affordable Studio in Business Bay" },
                    { new Guid("bb72f20c-cd2f-4d76-9f38-1a6b71baf271"), "8 Al Khawaneej Rd", 3, 4, 2, "Dubai", "Spacious family home with garden, close to schools and parks.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 1800000.00m, "Sale", "Family Home in Mirdif" },
                    { new Guid("c3dc7f4d-5236-4b2d-8a9d-037d3b9dce17"), "Bluewaters Island", 5, 5, 3, "Dubai", "Ultra-luxury penthouse with ocean view and private elevator.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 9000000.00m, "Sale", "Luxury Beach Penthouse" },
                    { new Guid("c6c1a6ec-87da-4013-baa6-93d4b1b18df8"), "Victory Heights", 1, 1, 1, "Dubai", "Affordable apartment with access to sports facilities.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 65000.00m, "Rent", "Apartment in Dubai Sports City" },
                    { new Guid("d047a35c-1b8c-49d2-961e-9f14d3a72b8c"), "Boulevard Central", 1, 1, 0, "Dubai", "Studio apartment within walking distance to Dubai Mall.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 95000.00m, "Rent", "Downtown Studio" },
                    { new Guid("e46c6bc7-b56c-4eb3-b6c8-6c92a64c2c76"), "Springs 15", 3, 3, 2, "Dubai", "Family villa in a gated community with lakes and parks.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 2100000.00m, "Sale", "Villa in The Springs" },
                    { new Guid("f32e2a94-4578-4f46-b3c3-629b032b88f2"), "45 Beachside Ave", 5, 6, 3, "Dubai", "Exclusive beachfront villa with private access to the beach and panoramic sea views.", "https://images.unsplash.com/photo-1580587771525-78b9dba3b914", 4500000.00m, "Sale", "Beachfront Villa in Jumeirah" },
                    { new Guid("f9f17c25-b92d-4cf7-9a58-89a6c3dd4f21"), "Dubai Marina Gate 1", 3, 3, 2, "Dubai", "Spacious apartment with marina view and premium facilities.", "https://images.unsplash.com/photo-1613490493576-7fde63acd811", 200000.00m, "Rent", "Luxury Apartment in Marina Gate" },
                    { new Guid("fd8b7e0c-38f3-4dd7-985b-8702646f316b"), "Al Barsha 1", 2, 2, 1, "Dubai", "Convenient apartment located near shopping and metro.", "https://images.unsplash.com/photo-1600585154340-be6161a56a0c", 85000.00m, "Rent", "Apartment near Mall of the Emirates" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PropertyId",
                table: "Favorites",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
