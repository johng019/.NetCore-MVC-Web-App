using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreWeb_App.Data.Migrations
{
    public partial class Aliases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliases",
                columns: table => new
                {
                    alias_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    criminal_id = table.Column<int>(nullable: false),
                    alias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliases", x => x.alias_id);
                });

            migrationBuilder.CreateTable(
                name: "Appeals",
                columns: table => new
                {
                    appeal_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crime_id = table.Column<int>(nullable: false),
                    filing_date = table.Column<string>(nullable: true),
                    hearing_date = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appeals", x => x.appeal_id);
                });

            migrationBuilder.CreateTable(
                name: "Crime_charges",
                columns: table => new
                {
                    charge_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crime_id = table.Column<int>(nullable: false),
                    crime_code = table.Column<int>(nullable: false),
                    charge_status = table.Column<string>(nullable: true),
                    fine_amount = table.Column<string>(nullable: true),
                    court_fee = table.Column<string>(nullable: true),
                    amount_paid = table.Column<string>(nullable: true),
                    pay_due_date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crime_charges", x => x.charge_id);
                });

            migrationBuilder.CreateTable(
                name: "CrimeCodes",
                columns: table => new
                {
                    crime_code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeCodes", x => x.crime_code);
                });

            migrationBuilder.CreateTable(
                name: "CrimeOfficers",
                columns: table => new
                {
                    crime_officer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crime_id = table.Column<int>(nullable: false),
                    officer_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeOfficers", x => x.crime_officer_id);
                });

            migrationBuilder.CreateTable(
                name: "Crimes",
                columns: table => new
                {
                    crime_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    criminal_id = table.Column<int>(nullable: false),
                    classification = table.Column<string>(nullable: true),
                    date_charged = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    hearing_date = table.Column<string>(nullable: true),
                    appeal_cut_date = table.Column<string>(nullable: true),
                    date_recorded = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crimes", x => x.crime_id);
                });

            migrationBuilder.CreateTable(
                name: "Criminals",
                columns: table => new
                {
                    criminal_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last = table.Column<string>(nullable: true),
                    first = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    v_status = table.Column<string>(nullable: true),
                    p_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criminals", x => x.criminal_id);
                });

            migrationBuilder.CreateTable(
                name: "CriminalsDW",
                columns: table => new
                {
                    criminal_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last = table.Column<string>(nullable: true),
                    first = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    v_status = table.Column<string>(nullable: true),
                    p_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriminalsDW", x => x.criminal_id);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    officer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last = table.Column<string>(nullable: true),
                    first = table.Column<string>(nullable: true),
                    precinct = table.Column<string>(nullable: true),
                    badge = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.officer_id);
                });

            migrationBuilder.CreateTable(
                name: "ProbationContact",
                columns: table => new
                {
                    probation_contact_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prob_cat = table.Column<int>(nullable: false),
                    low_amt = table.Column<int>(nullable: false),
                    high_amt = table.Column<int>(nullable: false),
                    con_freq = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationContact", x => x.probation_contact_id);
                });

            migrationBuilder.CreateTable(
                name: "ProbationOfficers",
                columns: table => new
                {
                    prob_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last = table.Column<string>(nullable: true),
                    first = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    mgr_id = table.Column<string>(nullable: true),
                    pager_num = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationOfficers", x => x.prob_id);
                });

            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    sentence_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    criminal_id = table.Column<int>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    prob_id = table.Column<int>(nullable: false),
                    start_date = table.Column<string>(nullable: true),
                    end_date = table.Column<string>(nullable: true),
                    violations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.sentence_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliases");

            migrationBuilder.DropTable(
                name: "Appeals");

            migrationBuilder.DropTable(
                name: "Crime_charges");

            migrationBuilder.DropTable(
                name: "CrimeCodes");

            migrationBuilder.DropTable(
                name: "CrimeOfficers");

            migrationBuilder.DropTable(
                name: "Crimes");

            migrationBuilder.DropTable(
                name: "Criminals");

            migrationBuilder.DropTable(
                name: "CriminalsDW");

            migrationBuilder.DropTable(
                name: "Officers");

            migrationBuilder.DropTable(
                name: "ProbationContact");

            migrationBuilder.DropTable(
                name: "ProbationOfficers");

            migrationBuilder.DropTable(
                name: "Sentences");
        }
    }
}
