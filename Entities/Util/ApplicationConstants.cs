using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Util
{
    public static class ApplicationConstants
    {
        public const string DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
        public const string DateFormat = "dd/MM/yyyy";
        public const string MonthYearFormat = "MMMM/yyyy";
        public const string TimeFormatHourMinute = @"hh\:mm";

        public const string NomeArquivoFotoPerfil = "Perfil.png";

        // Documentos
        public const string PastaDocumentos = "Documents";
        public const string ArquivoCracha = "cracha.docx";
        public const string CursoReplace = "{{CURSO}}";
        public const string NomeReplace = "{{NOME}}";
        public const string CPFReplace = "{{CPF}}";
        public const string MatriculaReplace = "{{MATRICULA}}";
        public const string TurmaReplace = "{{TURMA}}";
        public const string ValidadeReplace = "{{VALIDADE}}";
        public const string DataGeracaoReplace = "{{DATA_GERACAO}}";
    }
}
