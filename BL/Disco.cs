using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result Add (ML.Disco disco)
        {
            ML.Result result = new ML.Result ();
            try
            {
                using(DL.JGuevaraPruebaTecnicaEntities context = new DL.JGuevaraPruebaTecnicaEntities ())
                {
                    var query = context.DiscoAdd(disco.Titulo, disco.Duracion, disco.Anio, disco.Ventas, disco.Disponibilidad, disco.Artista.IdArtista, disco.GeneroMusical.IdGenero, disco.Distribuidora.IdDistribuidora);

                    if(query > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar";
                    }
                }

            } catch (Exception ex) {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraPruebaTecnicaEntities context = new DL.JGuevaraPruebaTecnicaEntities())
                {
                    var query = context.DiscoUpdate(disco.IdDisco, disco.Titulo, disco.Duracion, disco.Anio, disco.Ventas, disco.Disponibilidad, disco.Artista.IdArtista, disco.GeneroMusical.IdGenero, disco.Distribuidora.IdDistribuidora);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraPruebaTecnicaEntities context = new DL.JGuevaraPruebaTecnicaEntities())
                {
                    var query = context.DiscoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Disco disco = new ML.Disco();
                            disco.IdDisco = obj.IdDisco;
                            disco.Titulo = obj.Titulo;
                            disco.Duracion = obj.Duracion;
                            disco.Anio = obj.Anio;
                            disco.Ventas = (float)obj.Ventas;
                            disco.Disponibilidad = obj.Disponibilidad;

                            disco.Artista = new ML.Artista();
                            disco.GeneroMusical = new ML.Genero();
                            disco.Distribuidora = new ML.Distribuidora();

                            disco.Artista.IdArtista = obj.IdArtista;
                            disco.Artista.Nombre = obj.ArtistaNombre;
                            disco.Artista.ApellidoPaterno = obj.ApellidoPaterno;
                            disco.Artista.ApellidoMaterno = obj.ApellidoMaterno;
                            disco.Artista.FechaNacimiento = (DateTime)obj.FechaNacimiento;

                            disco.GeneroMusical.IdGenero = obj.IdGenero;
                            disco.GeneroMusical.Nombre = obj.GeneroNombre;

                            disco.Distribuidora.IdDistribuidora = obj.IdDistribuidora;
                            disco.Distribuidora.Nombre = obj.DistribuidoraNombre;
                            disco.Distribuidora.Direccion = obj.Direccion;
                            disco.Distribuidora.Telefono = obj.Telefono;
                            disco.Distribuidora.Correo = obj.CorreoElectronico;

                            result.Objects.Add(disco);

                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;

        }
    }
}
