namespace Persistence.Schemas;

public static class PatientSchema
{
    public const string Table = "patients";

    public class Columns : ColumnsBase
    {
        public const string FirstName = "first_name";

        public const string LastName = "last_name";

        public const string Patronymic = "patronymic";

        public const string Address = "address";

        public const string DateOfBirth = "date_of_birth";

        public const string Gender = "gender";

        public const string SectorId = "sector_id";
    }
}
