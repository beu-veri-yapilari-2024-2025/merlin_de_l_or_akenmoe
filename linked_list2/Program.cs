﻿using System;
using System.Collections.Generic;
using System.Linq;


public class StudentCourseNode
{
    public int StudentNumber;
    public string CourseCode;
    public string LetterGrade;

    public StudentCourseNode NextCourseForStudent  = null;
    public StudentCourseNode NextStudentInCourse  = null;
}
public class SchoolManagementLinkedList
{
    private Dictionary<int, StudentCourseNode> StudentHeads = new Dictionary<int, StudentCourseNode>();

    private Dictionary<string, StudentCourseNode> CourseHeads = new Dictionary<string, StudentCourseNode>();
    private List<StudentCourseNode> AllNodes  = new List<StudentCourseNode>();

    public SchoolManagementLinkedList()
    {
        
        AddNode(11, "BS11", "AA");
        AddNode(22, "BS11", "BA");
        AddNode(11, "MATH21", "BB");
        AddNode(33, "MATH21", "CC");
        AddNode(33, "PHYS11", "AA");
    }

    public void AddNode(int studentNo, string courseCode, string grade)
    {
        
        if (AllNodes.Any(n => n.StudentNumber == studentNo && n.CourseCode == courseCode))
        {
            Console.WriteLine($"ERROR: Student {studentNo} is already registered for course {courseCode}.");
            return;
        }

        var newNode = new StudentCourseNode
        {
            StudentNumber = studentNo,
            CourseCode = courseCode,
            LetterGrade = grade
        };

        
        if (StudentHeads.ContainsKey(studentNo))
        {
            var current = StudentHeads[studentNo];
            while (current.NextCourseForStudent != null)
            {
                current = current.NextCourseForStudent;
            }
            current.NextCourseForStudent = newNode;
        }
        else
        {
            StudentHeads[studentNo] = newNode;
        }
        if (CourseHeads.ContainsKey(courseCode))
        {
            var current = CourseHeads[courseCode];
            while (current.NextStudentInCourse != null)
            {
                current = current.NextStudentInCourse;
            }
            current.NextStudentInCourse = newNode;
        }
        else
        {
            CourseHeads[courseCode] = newNode;
        }

        
        AllNodes.Add(newNode);
        Console.WriteLine($"SUCCESS: Record for Student {studentNo} in {courseCode} ({grade}) added.");
    }

    
    public void DeleteNode(int studentNo, string courseCode)
    {
        
        var targetNode = AllNodes.FirstOrDefault(n => n.StudentNumber == studentNo && n.CourseCode == courseCode);

        if (targetNode == null)
        {
            Console.WriteLine($"ERROR: Record for Student {studentNo} in {courseCode} not found.");
            return;
        }

        
        if (StudentHeads.ContainsKey(studentNo))
        {
            StudentCourseNode studentPrev = null;
            var current = StudentHeads[studentNo];

            while (current != null && (current.StudentNumber != studentNo || current.CourseCode != courseCode))
            {
                studentPrev = current;
                current = current.NextCourseForStudent;
            }
            if (studentPrev == null)
            {
                
                StudentHeads[studentNo] = targetNode.NextCourseForStudent;
            }
            else
            {   
                studentPrev.NextCourseForStudent = targetNode.NextCourseForStudent;
            }            
            if (StudentHeads[studentNo] == null)
            {
                StudentHeads.Remove(studentNo);
            }
        }
        if (CourseHeads.ContainsKey(courseCode))
        {
            StudentCourseNode coursePrev = null;
            var current = CourseHeads[courseCode];

            while (current != null && (current.StudentNumber != studentNo || current.CourseCode != courseCode))
            {
                coursePrev = current;
                current = current.NextStudentInCourse;
            }

            if (coursePrev == null)
            {
                CourseHeads[courseCode] = targetNode.NextStudentInCourse;
            }
            else
            {
                coursePrev.NextStudentInCourse = targetNode.NextStudentInCourse;
            }
            if (CourseHeads[courseCode] == null)
            {
                CourseHeads.Remove(courseCode);
            }
        }
        AllNodes.Remove(targetNode);
        Console.WriteLine($"SUCCESS: Record for Student {studentNo} in {courseCode} deleted.");
    }

    public void ListStudentsInCourse(string courseCode)
    {
        Console.WriteLine($"\n--- {courseCode} Students (Sorted by Number) ---");

        if (!CourseHeads.ContainsKey(courseCode))
        {
            Console.WriteLine($"'{courseCode}' course has no registered students.");
            return;
        }

        
        var foundNodes = new List<StudentCourseNode>();
        var current = CourseHeads[courseCode];
        while (current != null)
        {
            foundNodes.Add(current);
            current = current.NextStudentInCourse;
        }
        var sortedNodes = foundNodes.OrderBy(n => n.StudentNumber).ToList();

        foreach (var node in sortedNodes)
        {
            Console.WriteLine($"No: {node.StudentNumber,-5} Code: {node.CourseCode,-10} Grade: {node.LetterGrade}");
        }
    }
    public void ListCoursesByStudent(int studentNo)
    {
        Console.WriteLine($"\n--- Student {studentNo} Courses (Sorted by Code) ---");

        if (!StudentHeads.ContainsKey(studentNo))
        {
            Console.WriteLine($"Student {studentNo} is not registered for any courses.");
            return;
        }
        var foundNodes = new List<StudentCourseNode>();
        var current = StudentHeads[studentNo];
        while (current != null)
        {
            foundNodes.Add(current);
            current = current.NextCourseForStudent;
        }
        var sortedNodes = foundNodes.OrderBy(n => n.CourseCode).ToList();

        foreach (var node in sortedNodes)
        {
            Console.WriteLine($"Code: {node.CourseCode,-10} No: {node.StudentNumber,-5} Grade: {node.LetterGrade}");
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var system = new SchoolManagementLinkedList();
        Console.WriteLine("Multi-Level Linked List System Initialized with Pointers.\n");
        system.ListStudentsInCourse("BS11");
        system.ListCoursesByStudent(11);
        system.AddNode(33, "ENG404", "BA");
        system.AddNode(44, "MATH21", "AA");
        system.DeleteNode(11, "BS11");
        Console.WriteLine("\n--- Verification after Add/Delete operations ---");
        system.ListStudentsInCourse("MATH21");
        system.ListCoursesByStudent(33);
        Console.ReadKey(); 
    }
}