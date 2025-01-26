<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Our Landing Page</title>
    <!-- Add Bootstrap CSS -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .hero {
            background: linear-gradient(to right, #4e54c8, #8f94fb);
            color: white;
            padding: 60px 20px;
            text-align: center;
        }

        .features {
            margin: 40px 0;
        }

        .feature-card {
            transition: transform 0.3s;
        }

            .feature-card:hover {
                transform: translateY(-10px);
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Hero Section -->
            <div class="hero">
                <h1>Welcome to Our Website</h1>
                <p>Your one-stop solution for amazing products and services.</p>
                <a href="#features" class="btn btn-light btn-lg">Explore More</a>
            </div>

            <!-- Features Section -->
            <div id="features" class="container features">
                <div class="row text-center">
                    <div class="col-lg-4 col-md-6 mb-4">
                        <div class="card feature-card p-3 shadow">
                            <img src="https://via.placeholder.com/150" class="card-img-top" alt="Feature 1" />
                            <div class="card-body">
                                <h5 class="card-title">Feature One</h5>
                                <p class="card-text">Discover our first amazing feature that simplifies your life.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 mb-4">
                        <div class="card feature-card p-3 shadow">
                            <img src="https://via.placeholder.com/150" class="card-img-top" alt="Feature 2" />
                            <div class="card-body">
                                <h5 class="card-title">Feature Two</h5>
                                <p class="card-text">Experience unparalleled quality with this outstanding feature.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 mb-4">
                        <div class="card feature-card p-3 shadow">
                            <img src="https://via.placeholder.com/150" class="card-img-top" alt="Feature 3" />
                            <div class="card-body">
                                <h5 class="card-title">Feature Three</h5>
                                <p class="card-text">Take advantage of our third feature to stay ahead.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Call-to-Action Section -->
            <div class="text-center py-5 bg-light">
                <h2>Ready to Get Started?</h2>
                <p>Join us today and take the first step towards success!</p>
                <a href="#" class="btn btn-primary btn-lg">Sign Up Now</a>
            </div>
        </div>
    </form>

    <!-- Add Bootstrap JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>
</body>
</html>
