// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiPatientsController.cs" company="Axioma X">
//  Copyright( c) 2017 Gabriel Porras
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </copyright>
// <summary>
//   Defines the ApiPatientsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyFaveDentist.Controllers
{
  using System.Data.Entity;
  using System.Data.Entity.Infrastructure;
  using System.Linq;
  using System.Net;
  using System.Web.Http;
  using System.Web.Http.Description;

  using MyFaveDentist.Models;

  /// <summary>
  /// The api patients controller.
  /// </summary>
  // ReSharper disable once StyleCop.SA1650
  public class ApiPatientsController: ApiController
  {
    /// <summary>
    /// The db.
    /// </summary>
    // ReSharper disable once StyleCop.SA1650
    private readonly MyFaveDentistDbContext db = new MyFaveDentistDbContext ();

    /// <summary>
    /// The get patients.
    /// GET: api/ApiPatients
    /// </summary>
    /// <returns>
    /// The <see cref="IQueryable"/>.
    /// </returns>
    // ReSharper disable once StyleCop.SA1650
    public IQueryable <Patient> GetPatients ()
    {
      return this.db.Patients;
    }

    /// <summary>
    /// The get patient.
    /// GET: api/ApiPatients/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(Patient) )]
    // ReSharper disable once StyleCop.SA1650
    public IHttpActionResult GetPatient ( int id )
    {
      Patient patient = this.db.Patients.Find ( id );
      if ( patient == null )
      {
        return this.NotFound ();
      }

      return this.Ok ( patient );
    }

    /// <summary>
    /// The put patient.
    /// PUT: api/ApiPatients/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <param name="patient">
    /// The patient.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(void) )]
    // ReSharper disable once StyleCop.SA1650
    public IHttpActionResult PutPatient ( int id, Patient patient )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.BadRequest ( this.ModelState );
      }

      if ( id != patient.Id )
      {
        return this.BadRequest ();
      }

      this.db.Entry ( patient ).State = EntityState.Modified;

      try
      {
        this.db.SaveChanges ();
      }
      catch ( DbUpdateConcurrencyException )
      {
        if ( !this.PatientExists ( id ) )
        {
          return this.NotFound ();
        }

        throw;
      }

      return this.StatusCode ( HttpStatusCode.NoContent );
    }

    /// <summary>
    /// The post patient.
    /// POST: api/ApiPatients
    /// </summary>
    /// <param name="patient">
    /// The patient.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(Patient) )]
    // ReSharper disable once StyleCop.SA1650
    public IHttpActionResult PostPatient ( Patient patient )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.BadRequest ( this.ModelState );
      }

      this.db.Patients.Add ( patient );
      this.db.SaveChanges ();

      return this.CreatedAtRoute ( "DefaultApi", new { id = patient.Id }, patient );
    }

    /// <summary>
    /// The delete patient.
    /// DELETE: api/ApiPatients/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(Patient) )]
    // ReSharper disable once StyleCop.SA1650
    public IHttpActionResult DeletePatient ( int id )
    {
      Patient patient = this.db.Patients.Find ( id );
      if ( patient == null )
      {
        return this.NotFound ();
      }

      this.db.Patients.Remove ( patient );
      this.db.SaveChanges ();

      return this.Ok ( patient );
    }

    /// <summary>
    /// The dispose.
    /// </summary>
    /// <param name="disposing">
    /// The disposing.
    /// </param>
    protected override void Dispose ( bool disposing )
    {
      if ( disposing )
      {
        this.db.Dispose ();
      }

      base.Dispose ( disposing );
    }

    /// <summary>
    /// The patient exists.
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private bool PatientExists ( int id )
    {
      return this.db.Patients.Count ( e => e.Id == id ) > 0;
    }
  }
}