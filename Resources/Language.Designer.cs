﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Language {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Language() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Language", typeof(Language).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Author.
        /// </summary>
        public static string Author {
            get {
                return ResourceManager.GetString("Author", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field can be maximum 160 characters long.
        /// </summary>
        public static string FieldMaxLength160 {
            get {
                return ResourceManager.GetString("FieldMaxLength160", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field is required.
        /// </summary>
        public static string FieldRequired {
            get {
                return ResourceManager.GetString("FieldRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Genre.
        /// </summary>
        public static string Genre {
            get {
                return ResourceManager.GetString("Genre", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value has to be between 1 and 5.
        /// </summary>
        public static string Range1to5 {
            get {
                return ResourceManager.GetString("Range1to5", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rating.
        /// </summary>
        public static string Rating {
            get {
                return ResourceManager.GetString("Rating", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title.
        /// </summary>
        public static string Title {
            get {
                return ResourceManager.GetString("Title", resourceCulture);
            }
        }
    }
}
