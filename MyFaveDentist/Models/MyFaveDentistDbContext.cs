// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyFaveDentistDbContext.cs" company="Axioma X">
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
//   Patient class to store info about clients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyFaveDentist.Models
{
  using System.Data.Entity;

  /// <summary>
  /// The my fave dentist db context.
  /// </summary>
  // ReSharper disable once StyleCop.SA1650
  public class MyFaveDentistDbContext: DbContext
  {
    /// <summary>
    /// Gets or sets the patients.
    /// </summary>
    public DbSet <Patient> Patients { get; set; }

    /// <summary>
    /// Gets or sets the treatments.
    /// </summary>
    public DbSet <Treatment> Treatments { get; set; }

    /// <summary>
    /// Gets or sets the treatments documents.
    /// </summary>
    public DbSet <TreatmentDoc> TreatmentsDocs { get; set; }
  }
}