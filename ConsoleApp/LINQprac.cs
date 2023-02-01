using ConsoleApp.Models;

namespace ConsoleApp;

public static class LINQprac{

    public static void FirstNameQuery(){
        List<Student> students = new List<Student>();
        //using .add method
        // student.Add(new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}});
        // student.Add(new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}});
        // student.Add(new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}});
        // student.Add(new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}});
        // student.Add(new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}});
        // student.Add(new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}});
        // student.Add(new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}});
        // student.Add(new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}});
        // student.Add(new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}});
        // student.Add(new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}});
        // student.Add(new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}});
        // student.Add(new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}});

        //using .addrange method

        students.AddRange(new Student[]{
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        });

        //LINQ to give students who have more than 90 in firtst index 0 
        var Studentquery = 
            from student in students 
            where student.Scores[0] > 90
            orderby student.Last ascending
            select student;

        

        foreach (var student in Studentquery){
            Console.WriteLine("{0}, {1}",student.Last,student.First);
        }

        var Studentquery2 = 
            from student in students
            group student by student.Last[0];

        Console.WriteLine();
        Console.WriteLine("Using group");
        foreach (var studentgroup in Studentquery2){
            Console.WriteLine(studentgroup.Key);
            foreach (var student in studentgroup){
                Console.WriteLine("  {0},{1}",student.Last,student.First);
            }
        }

        Console.WriteLine();


        var studentquery3 = 
            from student in students
            group student by student.Last[0] into studentGroup
            orderby studentGroup.Key
            select studentGroup;

        Console.WriteLine("using group with using orderby");
        foreach (var groupofstudents in studentquery3){
            Console.WriteLine(groupofstudents.Key);
            foreach(var student in groupofstudents){
                Console.WriteLine("  {0},{1}",student.Last,student.First);
            }
        }

        Console.WriteLine();

        var studentquery4 = 
            from student in students
            let totalscore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
            where totalscore / 4 < student.Scores[0]
            select student.Last + " " + student.First;
        
        foreach (var highavgscore in studentquery4){
            Console.WriteLine(highavgscore);
        }

        Console.WriteLine();

        var studentquery5 = 
            from student in students
            let totalscore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
            select totalscore;

        double averagescore = studentquery5.Average();
        Console.WriteLine("Class average score = {0}", averagescore);

        Console.WriteLine();



        var Studentquery6 = 
            from student in students 
            let score = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
            where score > averagescore
            select new { id = student.ID,score = score};

        foreach (var item in Studentquery6)
        {   
            Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
        }

    }


}

