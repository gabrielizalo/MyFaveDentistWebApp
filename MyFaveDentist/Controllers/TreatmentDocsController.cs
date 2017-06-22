// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreatmentDocsController.cs" company="Axioma X">
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
//   Defines the TreatmentDocsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyFaveDentist.Controllers
{
  using System.Data.Entity;
  using System.Linq;
  using System.Net;
  using System.Web.Mvc;

  using MyFaveDentist.Models;

  /// <summary>
  /// The treatment docs controller.
  /// </summary>
  public class TreatmentDocsController: Controller
  {
    /// <summary>
    /// The db.
    /// </summary>
    // ReSharper disable once StyleCop.SA1650
    private readonly MyFaveDentistDbContext db = new MyFaveDentistDbContext ();

    /// <summary>
    /// The index.
    /// GET: TreatmentDocs
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult Index ()
    {
      return this.View ( this.db.TreatmentsDocs.ToList () );
    }

    /// <summary>
    /// The details.
    /// GET: TreatmentDocs/Details/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult Details ( int? id )
    {
      if ( id == null )
      {
        return new HttpStatusCodeResult ( HttpStatusCode.BadRequest );
      }

      TreatmentDoc treatmentDoc = this.db.TreatmentsDocs.Find ( id );
      if ( treatmentDoc == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( treatmentDoc );
    }

    /// <summary>
    /// The create.
    /// GET: TreatmentDocs/Create
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult Create ()
    {
      return this.View ();
    }

    /// <summary>
    /// The create.
    /// POST: TreatmentDocs/Create
    /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
    /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    /// </summary>
    /// <param name="treatmentDoc">
    /// The treatment doc.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    // ReSharper disable once StyleCop.SA1650
    public ActionResult Create ( [Bind ( Include = "Id,TreatmentId,UrlDoc" )] TreatmentDoc treatmentDoc )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.View ( treatmentDoc );
      }

      this.db.TreatmentsDocs.Add ( treatmentDoc );
      this.db.SaveChanges ();
      return this.RedirectToAction ( "Index" );
    }

    /// <summary>
    /// The edit.
    /// GET: TreatmentDocs/Edit/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult Edit ( int? id )
    {
      if ( id == null )
      {
        return new HttpStatusCodeResult ( HttpStatusCode.BadRequest );
      }

      TreatmentDoc treatmentDoc = this.db.TreatmentsDocs.Find ( id );
      if ( treatmentDoc == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( treatmentDoc );
    }

    /// <summary>
    /// The edit.
    /// POST: TreatmentDocs/Edit/5
    /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
    /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    /// </summary>
    /// <param name="treatmentDoc">
    /// The treatment doc.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    // ReSharper disable once StyleCop.SA1650
    public ActionResult Edit ( [Bind ( Include = "Id,TreatmentId,UrlDoc" )] TreatmentDoc treatmentDoc )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.View ( treatmentDoc );
      }

      this.db.Entry ( treatmentDoc ).State = EntityState.Modified;
      this.db.SaveChanges ();
      return this.RedirectToAction ( "Index" );
    }

    /// <summary>
    /// The delete.
    /// GET: TreatmentDocs/Delete/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult Delete ( int? id )
    {
      if ( id == null )
      {
        return new HttpStatusCodeResult ( HttpStatusCode.BadRequest );
      }

      TreatmentDoc treatmentDoc = this.db.TreatmentsDocs.Find ( id );
      if ( treatmentDoc == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( treatmentDoc );
    }

    /// <summary>
    /// The delete confirmed.
    /// POST: TreatmentDocs/Delete/5
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost, ActionName ( "Delete" )]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed ( int id )
    {
      TreatmentDoc treatmentDoc = this.db.TreatmentsDocs.Find ( id );
      if ( treatmentDoc == null )
      {
        return this.RedirectToAction ( "Index" );
      }

      this.db.TreatmentsDocs.Remove ( treatmentDoc );
      this.db.SaveChanges ();
      return this.RedirectToAction ( "Index" );
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
  }
}
