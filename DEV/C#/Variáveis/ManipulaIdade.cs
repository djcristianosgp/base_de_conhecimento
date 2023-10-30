public class ManipulaIdade
{
    public class ItensIdade
    {
        public int ano { get; set; }
        public int mes { get; set; }
        public int dia { get; set; }
        public int hora { get; set; }
        public int minuto { get; set; }
        public int segundo { get; set; }

    }
    public static string GetIdadeCompleta(DateTime dataNascimento)
    {
        string sRetorno = string.Empty;

        var idade = GetClassItensIdade(dataNascimento);

        if (idade.ano == 0 || idade.ano == 1)
            sRetorno = idade.ano.ToString() + " ano, ";
        else
            sRetorno = idade.ano.ToString() + " anos, ";

        if (idade.mes == 0 || idade.mes == 1)
            sRetorno += idade.mes.ToString() + " mês, ";
        else
            sRetorno += idade.mes.ToString() + " meses, ";
        if (idade.dia == 0 || idade.dia == 1)
            sRetorno += idade.dia.ToString() + " dia, ";
        else
            sRetorno += idade.dia.ToString() + " dias, ";
        if (idade.hora == 0 || idade.hora == 1)
            sRetorno += idade.hora.ToString() + " hora, ";
        else
            sRetorno += idade.hora.ToString() + " horas, ";
        if (idade.minuto == 0 || idade.minuto == 1)
            sRetorno += idade.minuto.ToString() + " minuto, ";
        else
            sRetorno += idade.minuto.ToString() + " minutos, ";
        if (idade.segundo == 0 || idade.segundo == 1)
            sRetorno += idade.segundo.ToString() + " segundo, ";
        else
            sRetorno += idade.segundo.ToString() + " segundos, ";

        return sRetorno;
    }

    public static string GetIdadeAnoMesDia(DateTime dataNascimento)
    {
        string sRetorno = string.Empty;

        var idade = GetClassItensIdade(dataNascimento);

        if (idade.ano == 0 || idade.ano == 1)
            sRetorno = idade.ano.ToString() + " ano, ";
        else
            sRetorno = idade.ano.ToString() + " anos, ";

        if (idade.mes == 0 || idade.mes == 1)
            sRetorno += idade.mes.ToString() + " mês, ";
        else
            sRetorno += idade.mes.ToString() + " meses, ";
        if (idade.dia == 0 || idade.dia == 1)
            sRetorno += idade.dia.ToString() + " dia";
        else
            sRetorno += idade.dia.ToString() + " dias";

        return sRetorno;
    }

    public static string GetIdadeAnoMes(DateTime dataNascimento)
    {
        string sRetorno = string.Empty;

        var idade = GetClassItensIdade(dataNascimento);

        if (idade.ano == 0 || idade.ano == 1)
            sRetorno = idade.ano.ToString() + " ano, ";
        else
            sRetorno = idade.ano.ToString() + " anos, ";

        if (idade.mes == 0 || idade.mes == 1)
            sRetorno += idade.mes.ToString() + " mês";
        else
            sRetorno += idade.mes.ToString() + " meses";

        return sRetorno;
    }

    public static string GetIdadeMesDia(DateTime dataNascimento)
    {
        string sRetorno = string.Empty;

        var idade = GetClassItensIdade(dataNascimento);

        if (idade.mes == 0 || idade.mes == 1)
            sRetorno = idade.mes.ToString() + " mês, ";
        else
            sRetorno = idade.mes.ToString() + " meses, ";
        if (idade.dia == 0 || idade.dia == 1)
            sRetorno += idade.dia.ToString() + " dia";
        else
            sRetorno += idade.dia.ToString() + " dias";

        return sRetorno;
    }

    public static string RetornoDifDatas(DateTime datainicial,DateTime dataFinal)
    {
        string sRetorno = "";
        var retorno = DateTimeHelper.CalculaIdade(datainicial, dataFinal);

        sRetorno = retorno.Item1 > 1 ? retorno.Item1 + " anos, " : retorno.Item1 + " ano, ";
        sRetorno += retorno.Item2 > 1 ? retorno.Item2 + " meses, " : retorno.Item2 + " mês, ";
        sRetorno += retorno.Item3 > 1 ? retorno.Item3 + " dias. " : retorno.Item3 + " dia.";
        return sRetorno;
    }
    public static ItensIdade GetClassItensIdade(DateTime dataNascimento)
    {
        var idade = new ItensIdade();
        DateTime AnosTranscorridos = dataNascimento.AddYears(idade.ano);
        DateTime DataAtual = DateTime.Now;

        //Preencher ano
        idade.ano = new DateTime(DateTime.Now.Subtract(dataNascimento).Ticks).Year - 1;

        //Preencher mês
        idade.mes = 0;
        for (int i = 1; i <= 12; i++)
        {
            if (AnosTranscorridos.AddMonths(i) == DataAtual)
            {
                idade.mes = i;
                break;
            }
            else if (AnosTranscorridos.AddMonths(i) >= DataAtual)
            {
                idade.mes = i - 1;
                break;
            }
        }
        //Preencher dia
        idade.dia = DataAtual.Subtract(AnosTranscorridos.AddMonths(idade.mes)).Days;

        //Preencher horas
        idade.hora = DataAtual.Subtract(AnosTranscorridos).Hours;

        //Preencher minutos
        idade.minuto = DataAtual.Subtract(AnosTranscorridos).Minutes;

        //Preencher segundos
        idade.segundo = DataAtual.Subtract(AnosTranscorridos).Seconds;

        return idade;
    }
}
