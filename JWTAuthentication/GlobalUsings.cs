// Global using directives

global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Runtime.Intrinsics.Arm;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using JWTAuthentication.Const;
global using JWTAuthentication.Context;
global using JWTAuthentication.Features.GetUserInfoById;
global using JWTAuthentication.Features.Login;
global using JWTAuthentication.Features.Registration;
global using JWTAuthentication.Interfaces.Services;
global using JWTAuthentication.Models;
global using JWTAuthentication.Services;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;