using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Dto;

namespace ServiceLayer
{
    public class InspectionService
    {
        private readonly AppDataContext _context;

        public InspectionService(AppDataContext context)
        {
            _context = context;
        }

        public Inspection AddNewInspection(InspectionDto newInspection)
        {
            var inspection = new Inspection()
            {
                CompanyId = newInspection.CompanyId,
                Description = newInspection.Description,
                Reviews = newInspection.Reviews.Select(review => new Review()
                    { Comment = review.Comment, Question = review.Question, Score = review.Score }).ToList(),
                Responsible = newInspection.Responsible.Select(r=> new InspectionResponsible(){ ResponsibleId =  r.ResponsibleId}).ToList()
            };
            
            _context.Inspections.Add(inspection);
            _context.SaveChanges();
            return inspection;
        }


        public Review GetBlankReview(int inspectionId) 
        {
            return new Review
            {              
                InspectionId = inspectionId
            };              
        }
        
        public Inspection AddReviewToInspection(Review review)
        {
            var inspection = _context.Inspections   
                .Include(r => r.Reviews)
                .Single(k => k.InspectionId   
                             == review.InspectionId);
            inspection.Reviews.Add(review);
            _context.SaveChanges(); 
            return inspection;
        }


        public Status GetCurrentStatus(int inspectionId)
        {
            var inspection = _context.Inspections.Include(i => i.Status)
                .Single(i => i.InspectionId == inspectionId);
            return inspection?.Status ?? new Status()
            {
                InspectionId = inspectionId,
                IsOk = false
            };
        }

        public Inspection UpdateStatus(Status status)
        {
            var inspection = _context.Inspections
                .Include(r => r.Status)
                .Single(k => k.InspectionId
                             == status.InspectionId);

            if (inspection.Status == null)
            {
                inspection.Status = status;
            }
            else
            {
                inspection.Status.IsOk = status.IsOk;
                inspection.Status.Description = status.Description;
            }

            _context.SaveChanges();
            return inspection;
        }




    }
}
