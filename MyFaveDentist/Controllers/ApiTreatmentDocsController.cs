// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiTreatmentDocsController.cs" company="Axioma X">
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
//   Defines the ApiTreatmentDocsController type.
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
  /// The api treatment docs controller.
  /// </summary>
  // ReSharper disable once StyleCop.SA1650
  public class ApiTreatmentDocsController: ApiController
  {
    /// <summary>
    /// The db.
    /// </summary>
    private readonly MyFaveDentistDbContext db = new MyFaveDentistDbContext ();

    /// <summary>
    /// The get treatments docs.
    /// GET: api/ApiTreatmentDocs
    /// </summary>
    /// <returns>
    /// The <see cref="IQueryable"/>.
    /// </returns>
    public IQueryable <TreatmentDoc> GetTreatmentsDocs ()
    {
      return this.db.TreatmentsDocs;
    }

    /// <summary>
    /// The get treatment doc.
    /// GET: api/ApiTreatmentDocs/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(TreatmentDoc) )]
    public IHttpActionResult GetTreatmentDoc ( int id )
    {
      TreatmentDoc treatmentDoc = this.db.TreatmentsDocs.Find ( id );
      if ( treatmentDoc == null )
      {
        return this.NotFound ();
      }

      return this.Ok ( treatmentDoc );
    }

    /// <summary>
    /// The put treatment doc.
    /// PUT: api/ApiTreatmentDocs/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <param name="treatmentDoc">
    /// The treatment doc.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(void) )]
    public IHttpActionResult PutTreatmentDoc ( int id, TreatmentDoc treatmentDoc )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.BadRequest ( this.ModelState );
      }

      if ( id != treatmentDoc.Id )
      {
        return this.BadRequest ();
      }

      this.db.Entry ( treatmentDoc ).State = EntityState.Modified;

      try
      {
        this.db.SaveChanges ();
      }
      catch ( DbUpdateConcurrencyException )
      {
        if ( !this.TreatmentDocExists ( id ) )
        {
          return this.NotFound ();
        }

        throw;
      }

      return this.StatusCode ( HttpStatusCode.NoContent );
    }

    /// <summary>
    /// The post treatment doc.
    /// POST: api/ApiTreatmentDocs
    /// </summary>
    /// <param name="treatmentDoc">
    /// The treatment doc.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(TreatmentDoc) )]
    public IHttpActionResult PostTreatmentDoc ( TreatmentDoc treatmentDoc )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.BadRequest ( this.ModelState );
      }

      this.db.TreatmentsDocs.Add ( treatmentDoc );
      this.db.SaveChanges ();

      return this.CreatedAtRoute ( "DefaultApi", new { id = treatmentDoc.Id }, treatmentDoc );
    }

    /// <summary>
    /// The delete treatment doc.
    /// DELETE: api/ApiTreatmentDocs/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [ResponseType ( typeof(TreatmentDoc) )]
    public IHttpActionResult DeleteTreatmentDoc ( int id )
    {
      TreatmentDoc treatmentDoc = this.db.TreatmentsDocs.Find ( id );
      if ( treatmentDoc == null )
      {
        return this.NotFound ();
      }

      this.db.TreatmentsDocs.Remove ( treatmentDoc );
      this.db.SaveChanges ();

      return this.Ok ( treatmentDoc );
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
    /// The treatment doc exists.
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private bool TreatmentDocExists ( int id )
    {
      return this.db.TreatmentsDocs.Count ( e => e.Id == id ) > 0;
    }
  }
}