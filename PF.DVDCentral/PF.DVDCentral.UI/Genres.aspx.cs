﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.UI
{
    public partial class Genres : System.Web.UI.Page
    {
        List<Genre> genres;
        Genre genre;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                genres = GenreManager.Load();
                Rebind();

                Session["genres"] = genres;

                ddlGenres_SelectedIndexChanged(sender, e);
            }
            else
            {
                genres = (List<Genre>)Session["genres"];
            }
        }
        private void Rebind()
        {
            // Clear out the binding to the ddl
            ddlGenres.DataSource = null;

            // Rebind to the ddl
            ddlGenres.DataSource = genres;

            // Designate the field/property that will be displayed
            ddlGenres.DataTextField = "Description";

            // Designate the field/property that is the primary key.
            ddlGenres.DataValueField = "Id";

            // Do the binding
            ddlGenres.DataBind();

            txtDescription.Text = string.Empty;
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                genre = new Genre();
                genre.Description = txtDescription.Text;
                genre.Id = genres[ddlGenres.SelectedIndex].Id;

                int results = GenreManager.Insert(genre);
                Response.Write("Inserted " + results + " rows...");

                genres.Add(genre);

                Rebind();

                if (results > 0)
                {
                    ddlGenres.SelectedValue = genre.Id.ToString();
                }
                ddlGenres_SelectedIndexChanged(sender, e);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                genre = genres[ddlGenres.SelectedIndex];

                genre.Description = txtDescription.Text;
                // genre.DegreeTypeId = degreeTypes[ddlDegreeTypes.SelectedIndex].Id;

                int results = GenreManager.Update(genre);
                Response.Write("Updated " + results + " rows...");
                Rebind();

                if (results > 0)
                {
                    ddlGenres.SelectedValue = genre.Id.ToString();
                }
                ddlGenres_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                genre = genres[ddlGenres.SelectedIndex];

                int results = GenreManager.Delete(genre.Id);
                Response.Write("Deleted " + results + " rows...");
                genres.Remove(genre);
                Rebind();
                ddlGenres_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            genre = genres[ddlGenres.SelectedIndex];
            txtDescription.Text = genre.Description;
            ddlGenres.SelectedValue = genre.Id.ToString();
        }
    }
}