using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Schemas;

public static class DoctorSchema
{
    public const string Table = "doctors";

    public class Columns : ColumnsBase
    {
        public const string FIO = "fio";

        public const string CabinetId = "cabinet_id";

        public const string SpecializationId = "specialization_id";

        public const string SectorId = "sector_id";
    }
}
