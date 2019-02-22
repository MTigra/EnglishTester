﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterLib
{
    public class Student
    {
        private string email;
        private string password;
        private Answers answers;
        public Student(string email, string password)
        {
            if (!(email.Contains("@edu.hse.ru")) || (password.Length < 4))
                throw new ArgumentOutOfRangeException("Неверно введённые данные");
            if (!(Authentication(email, password)))
                throw new ArgumentOutOfRangeException("Неверно введённые данные");
            this.email = email;
            this.password = password;
        }
        public void AddAnswers(Answers answers)
        {
            this.answers = answers;
        } 
        public bool Authentication(string email, string password)
        {
            return true;
        }
    }

    public class Answers
    {
        private string[] answers;
        public Answers(int size)
        {
            if (size <= 0) throw new IndexOutOfRangeException();
            answers = new string[size];
        }
        public void AddAnswer(string answer)
        {
            int i;
            for (i = 0; answers[i] != null; i++)
                if (answers[i] == answer) return;
            answers[i] = answer;
        }
        public void DeleteAnswer(string answer)
        {
            int i, index = -1;
            for (i = 0; answers[i] != null; i++)
                if (answers[i] == answer) index = i;
            try
            {
                answers[index] = answers[i - 1];
            }
            catch(IndexOutOfRangeException e)
            {

            }
        }
        public bool isClear()
        {
            if (answers[0] == null) return true;
            return false;
        }
    }

    public class Question
    {
        //количество вариантов ответа. если ноль - то ответ нужно вводить самому
        private int type;
        //раздел. 1 - listening, 2 - reading, 3 - writing
        private int section;
        //текст вопроса
        private string text;
        //массив вариантов ответа (если тип = 0, массив пуст)
        private string[] answers;

        public Question(string question, int type, int section, string[] answers)
        {
            if (text == "") throw new ArgumentNullException();
            if ((section > 3) || (section < 0)) throw new ArgumentOutOfRangeException();
            if ((type < 0) || (type > 12)) throw new ArgumentOutOfRangeException();
            this.text = question;
            this.type = type;
            this.answers = answers;
            this.section = section;
        }
        public int Type()
        {
            return type;
        }
        public string Text()
        {
            return text;
        }
        public int Section()
        {
            return section;
        }
        public string[] Answers()
        {
            return answers;
        }
    }
}
