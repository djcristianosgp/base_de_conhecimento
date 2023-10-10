using FirebirdSql.Data.FirebirdClient;

public string strConexao = @"DataSource=localhost; Database=C:\Program Files (x86)\Firebird\Firebird_2_5\examples\empbuild\EMPLOYEE.FDB; username= SYSDBA; password = masterkey";
public FbConnection con;

private void btnConectar_Click(object sender, EventArgs e)
{
           con = new FbConnection(strConexao);
FbCommand comando = new FbCommand("SELECT * FROM EMPLOYEE", con);
      FbDataAdapter data = new FbDataAdapter(comando);
           DataSet dataset = new DataSet();
      con.Open();
           data.Fill(dataset, "EMPLOYEE");
      dataGridViewEmployee.DataSource = dataset;
           dataGridViewEmployee.DataMember = "EMPLOYEE";
      con.Close();
}
