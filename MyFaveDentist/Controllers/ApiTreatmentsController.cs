// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiTreatmentsController.cs" company="Axioma X">
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
//   Defines the ApiTreatmentsController type.
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
  /// The api treatments controller.
  /// </summary>
  public class ApiTreatmentsController: ApiController
  {
    /// <summary>
    /// The db.
    /// </summary>
    private readonly MyFaveDentistDbContext db = new MyFaveDentistDbContext ();

    /// <summary>
    /// The get treatments.
    /// GET: api/ApiTreatments
    /// </summary>
    /// <returns>
    /// The <see cref="IQueryable"/>.
    /// </returns>
    public IQueryable <Treatment> GetTreatments ()
    {
      return this.db.Treatments;
    }

    /// <summary>
    /// The get treatment.
    /// GET: api/ApiTreatments/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(Treatment) )]
    public IHttpActionResult GetTreatment ( int id )
    {
      Treatment treatment = this.db.Treatments.Find ( id );
      if ( treatment == null )
      {
        return this.NotFound ();
      }

      return this.Ok ( treatment );
    }

    /// <summary>
    /// The put treatment.
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <param name="treatment">
    /// The treatment.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(void) )]
    public IHttpActionResult PutTreatment ( int id, Treatment treatment )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.BadRequest ( this.ModelState );
      }

      if ( id != treatment.Id )
      {
        return this.BadRequest ();
      }

      this.db.Entry ( treatment ).State = EntityState.Modified;

      try
      {
        this.db.SaveChanges ();
      }
      catch ( DbUpdateConcurrencyException )
      {
        if ( !this.TreatmentExists ( id ) )
        {
          return this.NotFound ();
        }

        throw;
      }

      return this.StatusCode ( HttpStatusCode.NoContent );
    }

    /// <summary>
    /// The post treatment.
    /// POST: api/ApiTreatments
    /// </summary>
    /// <param name="treatment">
    /// The treatment.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(Treatment) )]
    public IHttpActionResult PostTreatment ( Treatment treatment )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.BadRequest ( this.ModelState );
      }

      this.db.Treatments.Add ( treatment );
      this.db.SaveChanges ();

      return this.CreatedAtRoute ( "DefaultApi", new { id = treatment.Id }, treatment );
    }

    /// <summary>
    /// The delete treatment.
    /// DELETE: api/ApiTreatments/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(Treatment) )]
    public IHttpActionResult DeleteTreatment ( int id )
    {
      Treatment treatment = this.db.Treatments.Find ( id );
      if ( treatment == null )
      {
        return this.NotFound ();
      }

      this.db.Treatments.Remove ( treatment );
      this.db.SaveChanges ();

      return this.Ok ( treatment );
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
    /// The treatment exists.
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private bool TreatmentExists ( int id )
    {
      return this.db.Treatments.Count ( e => e.Id == id ) > 0;
    }
  }
}