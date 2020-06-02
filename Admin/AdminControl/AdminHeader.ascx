<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdminHeader.ascx.vb" Inherits="Admin_AdminControl_AdminHeader" %>

	<header class="header-wrapper">
		<div class="container">
            	<div class="col-lg-3 col-md-3 col-sm-3">
                    <a class="cssLogo" href="Default.aspx"><img style="height:90px;" src="/images/bsic_logo.png" alt="" /></a>
                </div>
            	<div class="col-lg-9 col-md-9 col-sm-12">
                      <nav class="navbar navbar-default fhmm" role="navigation">
                        <div class="navbar-header">
                            <button type="button" data-toggle="collapse" data-target="#defaultmenu" class="navbar-toggle"><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                        </div><!-- end navbar-header -->
                        <div id="defaultmenu" class="navbar-collapse collapse container">
                            <ul class="nav navbar-nav">
                                <li class="active"><a href="/Admin/Default"> Home</a></li><!-- end standard li -->
                                <li class="active"><a href="/Admin/Registered">Reg. Students</a></li><!-- end standard li -->
                                <li class="active"><a href="/Admin/Paid"> Paid Students</a></li><!-- end standard li -->
                                <li class="active"><a href="/Admin/Enrolled"> Enrolled Students</a></li><!-- end standard li -->

                               
                                <li class=""><a href="/ChangePassword"> Change Password</a></li><!-- end standard li -->
                                <li class=""><a href="/Logout"> Logout</a></li><!-- end standard li -->
                            </ul><!-- end nav navbar-nav -->
                        </div><!-- end #navbar-collapse-1 -->
					</nav><!-- end navbar navbar-default fhmm -->
            	</div><!-- /col10 -->
		</div><!-- /container -->
    </header><!-- /header wrapper -->