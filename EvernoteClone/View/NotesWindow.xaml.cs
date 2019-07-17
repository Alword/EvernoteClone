﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Speech;
using System.Speech.Recognition;
using System.Threading;
using System.Globalization;

namespace EvernoteClone.View
{
    /// <summary>
    /// Логика взаимодействия для NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        private SpeechRecognitionEngine recognitionEngine;

        public NotesWindow()
        {
            InitializeComponent();
        }

        private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            contentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(e.Result.Text)));
        }

        private void Content_TextChanged(object sender, TextChangedEventArgs e)
        {
            int charactersCount = (new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd)).Text.Length;
            StatusTextBlock.Text = $"Document length: {charactersCount} characters";
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
        }

        bool isRecognizing = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isRecognizing)
            {
                recognitionEngine.RecognizeAsyncStop();
            }
            else
            {
                recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            isRecognizing = !isRecognizing;
            string textRange = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd).Text;
        }
    }
}
