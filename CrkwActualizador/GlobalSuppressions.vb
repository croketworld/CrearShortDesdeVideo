' This file is used by Code Analysis to maintain SuppressMessage
' attributes that are applied to this project.
' Project-level suppressions either have no target or are given
' a specific target and scoped to a namespace, type, member, etc.

Imports System.Diagnostics.CodeAnalysis

<Assembly: SuppressMessage("Design", "CA1056:Las propiedades de tipo URI no deben ser cadenas", Justification:="<pendiente>", Scope:="member", Target:="~P:Crkw.Actualizador.AppUpdateManifest.UrlDescarga")>
<Assembly: SuppressMessage("Naming", "CA1721:Los nombres de propiedades no deben coincidir con los métodos get", Justification:="<pendiente>", Scope:="member", Target:="~P:Crkw.Actualizador.AppUpdateManifest.Version")>
<Assembly: SuppressMessage("Design", "CA1031:No capture tipos de excepción generales.", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.AppUpdateManifest.GetVersion~System.Version")>
<Assembly: SuppressMessage("Design", "CA1024:Usar propiedades donde corresponda", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.AppUpdateManifest.GetVersion~System.Version")>
<Assembly: SuppressMessage("Performance", "CA1806:No omitir resultados del método", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.AppUpdateManifest.GetFecha~System.DateTime")>
<Assembly: SuppressMessage("Naming", "CA1721:Los nombres de propiedades no deben coincidir con los métodos get", Justification:="<pendiente>", Scope:="member", Target:="~P:Crkw.Actualizador.AppUpdateManifest.Fecha")>
<Assembly: SuppressMessage("Naming", "CA1721:Los nombres de propiedades no deben coincidir con los métodos get", Justification:="<pendiente>", Scope:="member", Target:="~P:Crkw.Actualizador.AppUpdateManifest.Notas")>
<Assembly: SuppressMessage("Usage", "CA2225:Las sobrecargas del operador tienen alternativas con nombre", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.AppUpdateManifest.op_GreaterThan(Crkw.Actualizador.AppUpdateManifest,System.String)~System.Boolean")>
<Assembly: SuppressMessage("Usage", "CA2225:Las sobrecargas del operador tienen alternativas con nombre", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.AppUpdateManifest.op_LessThan(Crkw.Actualizador.AppUpdateManifest,System.String)~System.Boolean")>
<Assembly: SuppressMessage("Usage", "CA2225:Las sobrecargas del operador tienen alternativas con nombre", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.AppUpdateManifest.op_GreaterThan(Crkw.Actualizador.AppUpdateManifest,Crkw.Actualizador.AppUpdateManifest)~System.Boolean")>
<Assembly: SuppressMessage("Usage", "CA2225:Las sobrecargas del operador tienen alternativas con nombre", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.AppUpdateManifest.op_LessThan(Crkw.Actualizador.AppUpdateManifest,Crkw.Actualizador.AppUpdateManifest)~System.Boolean")>
<Assembly: SuppressMessage("Maintainability", "CA1515:Considere la posibilidad de hacer que los tipos públicos sean internos", Justification:="<pendiente>", Scope:="type", Target:="~T:Crkw.Actualizador.AppUpdateManifest")>
<Assembly: SuppressMessage("Design", "CA1055:Los valores devueltos de tipo URI no deben ser cadenas", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.CroketWorldConstants.GetUrlForAppUpdateManifest(System.String,System.String)~System.String")>
<Assembly: SuppressMessage("Maintainability", "CA1515:Considere la posibilidad de hacer que los tipos públicos sean internos", Justification:="<pendiente>", Scope:="type", Target:="~T:Crkw.Actualizador.CroketWorldConstants")>
<Assembly: SuppressMessage("Performance", "CA1815:Reemplazar Equals y el operador Equals en los tipos de valor", Justification:="<pendiente>", Scope:="type", Target:="~T:Crkw.Actualizador.CroketWorldConstants")>
<Assembly: SuppressMessage("Design", "CA1055:Los valores devueltos de tipo URI no deben ser cadenas", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.CroketWorldConstants.GetUrlForAppUpdateManifest(System.String)~System.String")>
<Assembly: SuppressMessage("Design", "CA1052:Los tipos de contenedor estáticos deben ser Static o NotInheritable", Justification:="<pendiente>", Scope:="type", Target:="~T:Crkw.Actualizador.GetManifestsHelper")>
<Assembly: SuppressMessage("Maintainability", "CA1515:Considere la posibilidad de hacer que los tipos públicos sean internos", Justification:="<pendiente>", Scope:="type", Target:="~T:Crkw.Actualizador.GetManifestsHelper")>
<Assembly: SuppressMessage("Design", "CA1031:No capture tipos de excepción generales.", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.GetManifestsHelper.AppupdatemanifestDownloaded(System.Object,System.ComponentModel.AsyncCompletedEventArgs)")>
<Assembly: SuppressMessage("Reliability", "CA2000:Desechar (Dispose) objetos antes de perder el ámbito", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.GetManifestsHelper.GetAppUpdateManifest(System.String,System.String)")>
<Assembly: SuppressMessage("Design", "CA1031:No capture tipos de excepción generales.", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.GetManifestsHelper.DeserializeAppUpdateManfiest~Crkw.Actualizador.AppUpdateManifest")>
<Assembly: SuppressMessage("Usage", "CA2211:Los campos no constantes no deben ser visibles", Justification:="<pendiente>", Scope:="member", Target:="~F:Crkw.Actualizador.GetManifestsHelper.LastAppUpdateManifestDownloaded")>
<Assembly: SuppressMessage("Design", "CA1031:No capture tipos de excepción generales.", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.SerializationHelper.Deserialize``1(System.IO.Stream)~``0")>
<Assembly: SuppressMessage("Design", "CA1031:No capture tipos de excepción generales.", Justification:="<pendiente>", Scope:="member", Target:="~M:Crkw.Actualizador.SerializationHelper.Serialize``1(``0)~System.IO.Stream")>
<Assembly: SuppressMessage("Design", "CA1052:Los tipos de contenedor estáticos deben ser Static o NotInheritable", Justification:="<pendiente>", Scope:="type", Target:="~T:Crkw.Actualizador.SerializationHelper")>
<Assembly: SuppressMessage("Maintainability", "CA1515:Considere la posibilidad de hacer que los tipos públicos sean internos", Justification:="<pendiente>", Scope:="type", Target:="~T:Crkw.Actualizador.SerializationHelper")>
