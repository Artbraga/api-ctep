using Entities.DTOs;
using Entities.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace AssistantOperations.Boletos
{
    public class CsvBoletoMapping : CsvMapping<BoletoDTO>
    {
        public CsvBoletoMapping(): base()
        {
            var dateConverter = new DateConverter();
            var dateNullConverter = new DateNullConverter();
            var floatConverter = new FloatConverter();
            var floatNullConverter = new FloatNullConverter();
            MapProperty(1, x => x.NomeAluno);
            MapProperty(7, x => x.Status);
            MapProperty(9, x => x.SeuNumero);
            MapProperty(10, x => x.NossoNumero);
            MapProperty(11, x => x.DataEmissao, dateNullConverter);
            MapProperty(12, x => x.Valor, floatConverter);
            MapProperty(13, x => x.DataVencimento, dateConverter);
            MapProperty(14, x => x.ValorPago, floatNullConverter);
            MapProperty(15, x => x.DataPagamento, dateNullConverter);
            MapProperty(17, x => x.ValorJuros, floatNullConverter);
        }
    }
    class DateNullConverter : ITypeConverter<DateTime?>
    {
        public Type TargetType => typeof(DateTime?);
        public bool TryConvert(string value, out DateTime? result)
        {
            if (value.Length == 10) result = DateTime.ParseExact(value, ApplicationConstants.DateFormat, CultureInfo.InvariantCulture);
            else result = null;
            return true;
        }
    }
    class DateConverter : ITypeConverter<DateTime>
    {
        public Type TargetType => typeof(DateTime);
        public bool TryConvert(string value, out DateTime result)
        {
            result = DateTime.ParseExact(value, ApplicationConstants.DateFormat, CultureInfo.InvariantCulture);
            return true;
        }
    }
    class FloatConverter : ITypeConverter<float>
    {
        public Type TargetType => typeof(float);
        private CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();

        public bool TryConvert(string value, out float result)
        {
            ci.NumberFormat.NumberDecimalSeparator = ",";
            result = float.Parse(value, ci);
            return true;
        }
    }
    class FloatNullConverter : ITypeConverter<float?>
    {
        public Type TargetType => typeof(float);
        private CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();

        public bool TryConvert(string value, out float? result)
        {
            ci.NumberFormat.NumberDecimalSeparator = ",";
            if (value == null) result = null;
            else result = float.Parse(value, ci);
            return true;
        }
    }

}
