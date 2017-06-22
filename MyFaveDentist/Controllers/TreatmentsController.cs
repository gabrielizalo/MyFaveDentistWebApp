// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreatmentsController.cs" company="Axioma X">
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
//   Defines the TreatmentsController type.
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
  /// The treatments controller.
  /// </summary>
  public class TreatmentsController: Controller
  {
    /// <summary>
    /// The db.
    /// </summary>
    // ReSharper disable once StyleCop.SA1650
    private readonly MyFaveDentistDbContext db = new MyFaveDentistDbContext ();

    /// <summary>
    /// The index.
    /// GET: Treatments
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult Index ()
    {
      return this.View ( this.db.Treatments.ToList () );
    }

    /// <summary>
    /// The details.
    /// GET: Treatments/Details/5
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

      Treatment treatment = this.db.Treatments.Find ( id );
      if ( treatment == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( treatment );
    }

    /// <summary>
    /// The create.
    /// GET: Treatments/Create
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
    /// POST: Treatments/Create
    /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
    /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    /// </summary>
    /// <param name="treatment">
    /// The treatment.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    // ReSharper disable once StyleCop.SA1650
    public ActionResult Create ( [Bind ( Include = "Id,PatientId,IniDate,EndDate,Price,Details" )] Treatment treatment )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.View ( treatment );
      }

      this.db.Treatments.Add ( treatment );
      this.db.SaveChanges ();
      return this.RedirectToAction ( "Index" );
    }

    /// <summary>
    /// The edit.
    /// GET: Treatments/Edit/5
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

      Treatment treatment = this.db.Treatments.Find ( id );
      if ( treatment == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( treatment );
    }

    /// <summary>
    /// The edit.
    /// POST: Treatments/Edit/5
    /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
    /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    /// </summary>
    /// <param name="treatment">
    /// The treatment.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    // ReSharper disable once StyleCop.SA1650
    public ActionResult Edit ( [Bind ( Include = "Id,PatientId,IniDate,EndDate,Price,Details" )] Treatment treatment )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.View ( treatment );
      }

      this.db.Entry ( treatment ).State = EntityState.Modified;
      this.db.SaveChanges ();
      return this.RedirectToAction ( "Index" );
    }

    /// <summary>
    /// The delete.
    /// GET: Treatments/Delete/5
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

      Treatment treatment = this.db.Treatments.Find ( id );
      if ( treatment == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( treatment );
    }

    /// <summary>
    /// The delete confirmed.
    /// POST: Treatments/Delete/5
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
      Treatment treatment = this.db.Treatments.Find ( id );
      if ( treatment == null )
      {
        return this.RedirectToAction ( "Index" );
      }

      this.db.Treatments.Remove ( treatment );
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
