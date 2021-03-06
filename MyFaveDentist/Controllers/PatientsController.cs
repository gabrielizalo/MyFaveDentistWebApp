﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PatientsController.cs" company="Axioma X">
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
//   Defines the PatientsController type.
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
  /// The patients controller.
  /// </summary>
  public class PatientsController: Controller
  {
    /// <summary>
    /// The db.
    /// </summary>
    // ReSharper disable once StyleCop.SA1650
    private readonly MyFaveDentistDbContext db = new MyFaveDentistDbContext ();

    /// <summary>
    /// GET: Patients
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult Index ()
    {
      return this.View ( this.db.Patients.ToList () );
    }

    /// <summary>
    /// GET: Patients/Details/5
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

      var patient = this.db.Patients.Find ( id );
      if ( patient == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( patient );
    }

    /// <summary>
    /// GET: Patients/Create
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult Create ()
    {
      return this.View ();
    }

    /// <summary>
    /// POST: Patients/Create
    /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
    /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    /// </summary>
    /// <param name="patient">
    /// The patient.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    // ReSharper disable once StyleCop.SA1650
    public ActionResult Create (
      [Bind ( Include = "Id,Name,PersonalId,BirthDate,Cellphone,Phone,Email,LastVisitDate,NextVisitDate" )]
      Patient patient )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.View ( patient );
      }

      this.db.Patients.Add ( patient );
      this.db.SaveChanges ();
      return this.RedirectToAction ( "Index" );
    }

    /// <summary>
    /// GET: Patients/Edit/5
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

      Patient patient = this.db.Patients.Find ( id );
      if ( patient == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( patient );
    }

    /// <summary>
    /// POST: Patients/Edit/5
    /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
    /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    /// </summary>
    /// <param name="patient">
    /// The patient.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    // ReSharper disable once StyleCop.SA1650
    public ActionResult Edit (
      [Bind ( Include = "Id,Name,PersonalId,BirthDate,Cellphone,Phone,Email,LastVisitDate,NextVisitDate" )]
      Patient patient )
    {
      if ( !this.ModelState.IsValid )
      {
        return this.View ( patient );
      }

      this.db.Entry ( patient ).State = EntityState.Modified;
      this.db.SaveChanges ();
      return this.RedirectToAction ( "Index" );
    }

    /// <summary>
    /// GET: Patients/Delete/5
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

      Patient patient = this.db.Patients.Find ( id );
      if ( patient == null )
      {
        return this.HttpNotFound ();
      }

      return this.View ( patient );
    }

    /// <summary>
    /// POST: Patients/Delete/5
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
      Patient patient = this.db.Patients.Find ( id );
      if ( patient == null )
      {
        return this.RedirectToAction ( "Index" );
      }

      this.db.Patients.Remove ( patient );
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
