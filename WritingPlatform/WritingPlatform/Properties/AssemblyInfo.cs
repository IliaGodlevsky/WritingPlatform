﻿using System.Reflection;
using System.Runtime.InteropServices;
using WebActivatorEx;
using WritingPlatform.App_Start;

// Управление общими сведениями о сборке осуществляется следующим образом
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанных с этой сборкой.
[assembly: AssemblyTitle("WritingPlatform")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("WritingPlatform")]
[assembly: AssemblyCopyright("© , 2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Установка значения False в параметре ComVisible делает типы в этой сборке невидимыми
// для компонентов COM.  Если требуется обратиться к типу в этой сборке через
// COM, задайте атрибуту ComVisible значение true для требуемого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для ID библиотеки типов typelib, если этот проект видим для COM
[assembly: Guid("8203e317-6bdf-46a0-bbfd-53ebcc3c1b5d")]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      основной номер версии;
//      Дополнительный номер версии
//      номер сборки;
//      редакция.
//
// Можно задать все значения или принять номер редакции и номер сборки по умолчанию,
// используя "*", как показано ниже:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: PreApplicationStartMethod(typeof(DependencyInjectionConfig), "Start")]
