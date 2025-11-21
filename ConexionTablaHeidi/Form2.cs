using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ConexionTablaHeidi
{
    public partial class Form2 : Form
    {
        public int alumnoId = -1;

        public Form2()
        {
            InitializeComponent();
        }

        private void AgregarAlumno()
        {
            string conexionString = "Server=localhost;Database=instituto;Uid=root;Pwd=1234;";
            string query = "INSERT INTO alumnos (nombre, apellido, provincia, telefono, nota) VALUES (@nombre, @apellido, @provincia, @telefono, @nota)";

            try
            {
                // VALIDACIONES MÍNIMAS
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(textBoxApellido.Text))
                {
                    MessageBox.Show("Nombre y apellido son obligatorios.");
                    return;
                }

                using (MySqlConnection conexion = new MySqlConnection(conexionString))
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                    comando.Parameters.AddWithValue("@apellido", textBoxApellido.Text);
                    comando.Parameters.AddWithValue("@provincia", textBoxProvincia.Text);
                    comando.Parameters.AddWithValue("@telefono", textBoxTelefono.Text);

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        MessageBox.Show("Alumno agregado correctamente.");
                    else
                        MessageBox.Show("No se pudo agregar el alumno.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            if (alumnoId == -1)
            {
                AgregarAlumno();
            }
            else
            {
                ModificarAlumno();
            }

            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (alumnoId != -1)
            {
                CargarDatosAlumnos();
            }
        }

        private void CargarDatosAlumnos()
        {
            string conexionString = "Server=localhost;Database=instituto;Uid=root;Pwd=1234;";
            string query = "SELECT * FROM alumnos WHERE id = @id";

            using (MySqlConnection conexion = new MySqlConnection(conexionString))
            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", alumnoId);

                conexion.Open();
                MySqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    textBoxNombre.Text = lector["nombre"].ToString();
                    textBoxApellido.Text = lector["apellido"].ToString();
                    textBoxProvincia.Text = lector["provincia"].ToString();
                    textBoxTelefono.Text = lector["telefono"].ToString();
                }
            }
        }

        private void ModificarAlumno()
        {
            string conexionString = "Server=localhost;Database=instituto;Uid=root;Pwd=1234;";
            string query = "UPDATE alumnos SET nombre=@nombre, apellido=@apellido, provincia=@provincia, telefono=@telefono, nota=@nota WHERE id=@id";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionString))
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                    comando.Parameters.AddWithValue("@apellido", textBoxApellido.Text);
                    comando.Parameters.AddWithValue("@provincia", textBoxProvincia.Text);
                    comando.Parameters.AddWithValue("@telefono", textBoxTelefono.Text);
                    comando.Parameters.AddWithValue("@id", alumnoId);

                    conexion.Open();
                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                        MessageBox.Show("Alumno modificado correctamente.");
                    else
                        MessageBox.Show("No se pudo modificar el alumno.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Handlers vacíos (no elimino nada porque eran tuyos)
        private void textBoxNombre_TextChanged(object sender, EventArgs e) { }
        private void textBoxApellido_TextChanged(object sender, EventArgs e) { }
        private void textBoxProvincia_TextChanged(object sender, EventArgs e) { }
        private void textBoxTelefono_TextChanged(object sender, EventArgs e) { }
        private void textBoxNota_TextChanged(object sender, EventArgs e) { }
    }
}
