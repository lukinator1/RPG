import React, { Component } from 'react';
import * as usersAPI from './utils/usersAPI';
import serializeForm from 'form-serialize';
import { Redirect } from 'react-router-dom';
import "./assets/css/validation.scoped.css";

class SignupForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      username: '',
      password: '',
      confirmation: null,
      redirect: null,
      passError: ''
    }
  }

  handleSubmit = async e => {
    e.preventDefault();
    const values = serializeForm(e.target, { hash: true })
    
    console.log("values is", values);
    
    const res = await usersAPI.registerUser({ values })
    
    if (res.errorMessage) {
      const element = <p className="borderError" >{res.errorMessage}</p>
      this.props.onMessageChange(element);
    } else {
      const element = res.errorMessage
      this.props.onMessageChange(element);
    }
    
    if ('details' in res) {
      console.log("the result m:", res.details[0]);
      if (res.details[0].param === 'password') {
        this.setState({ passError: res.details[0].msg });
      }
    }
    
    if (res != null && 'Message' in res && res.Message === "Signup successfully!") {
      setTimeout(() => {  
        this.setState({ redirect: "/users/login" })
        }, 25000)
        this.setState({confirmation: 'block'});
    }

    const { email } = values
    usersAPI.sendWelcome(email.replace(/^[ '"]+|[ '"]+$|( ){2,}/g, '$1'))
  }


  render() {
    if (this.state.redirect) {
      return <Redirect to={this.state.redirect} />
    }
    else if (this.state.confirmation){
      return(
      <div className="confirmation-message" style={{display: 'block', width: '100%', height: '100%', position: 'fixed', bottom: '50%', right: '50%',  transform: 'translate(50%, 50%)', backgroundColor: '#cc3366'}}>
            <p className = "confirmation-message-text" style = {{position: 'relative', top: '50%', transform: 'translate(0, -50%)', marginLeft: '30%', marginRight: '30%'}}>
            Congratulations! You are registered, please check your email to confirm your registration.
            </p>
        </div>)
    }
    return (
      <form onSubmit={this.handleSubmit}>
        <div className="form-group">
          <label style={{ marginLeft: '-273px', fontFamily: '"Roboto Condensed", sans-serif' }}>First Name</label>
          <input id="fname" name="fname" type="text" placeholder="Enter First Name" className="form-control container" />
        </div>
        <div className="form-group">
          <label style={{ marginLeft: '-276px', fontFamily: '"Roboto Condensed", sans-serif' }}>Last Name</label>
          <input id="lname" name="lname" type="text" placeholder="Enter Last Name" className="form-control container" />
        </div>
        <div className="form-group">
          <label style={{ marginLeft: '-310px', fontFamily: '"Roboto Condensed", sans-serif' }}>Email</label>
          <input id="email" name="email" type="email" placeholder="Email" className="form-control container" />
        </div>
        <div className="form-group tooltip">
          <label style={{ marginLeft: '-283px', fontFamily: '"Roboto Condensed", sans-serif' }}>Password</label><p style={{
            display: 'inline-block',
            color: 'yellow', marginLeft: '5px', fontSize: 'small'
          }}>{this.state.passError}</p>
          <input id="password" name="password" type="password" placeholder="Enter Password" className="form-control container" /><span className="tooltiptext">Password requirements are: 8 characters min length.<br></br> At least 1 capital letter.<br></br> At least 1 number.<br></br> At least 1 symbol.</span>
        </div>
        <div className="form-group">
          <label style={{ marginLeft: '-232px', fontFamily: '"Roboto Condensed", sans-serif' }}>Confirm Password</label>
          <input id="password2" name="password2" type="password" placeholder="Confirm Password" className="form-control container" />
        </div>
        <div className="form-group">
          <label style={{ marginLeft: '-224px', fontFamily: '"Roboto Condensed", sans-serif' }}>Type your Affiliation</label>
          <input id="affiliation" name="affiliation" type="text" placeholder="Type in your organization name if you belong to one" className="form-control container" />
        </div>
        {/* <div className="form-group">
              <label style={{marginLeft: '-263px', fontFamily: '"Roboto Condensed", sans-serif'}}>Coupon code</label>
              <input id="coupon" name="coupon" type="text" placeholder="Type your coupon code" className="form-control container" />
            </div> */}
        {/* <p style={{fontSize: 14, fontFamily: '"Roboto Condensed"', fontWeight: 'bold', float: 'left', marginLeft: 25}}>Are you an instructor?</p> */}
        <div>
          <p style={{ fontFamily: '"Roboto Condensed"', fontWeight: 'bold', fontSize: 15, textAlign: 'left', marginLeft: 25 }}>
            <input type="checkbox" id="instructor" name="instructor" /> Are you an instructor that want to teach?</p>
        </div>
        <div style={{ fontFamily: '"Roboto Condensed", sans-serif', fontWeight: 300, fontSize: 15, textAlign: 'left', marginLeft: 25 }}>
          <input type="checkbox" id="newsletter" name="newsletter" style={{ paddingTop: 25, marginTop: 15 }} /> Sign me up for the newsletter, I like to stay informed.
        </div>

        <div style={{ fontFamily: '"Roboto Condensed", sans-serif', fontWeight: 300, fontSize: 15, textAlign: 'left', marginLeft: 25 }}>
          <input type="checkbox" id="toagree" name="toagree" style={{ paddingTop: 25, marginTop: 15 }} /> I agree to the Dance4Healing <a href="/terms.pdf" style={{ textDecoration: 'underline' }}>Terms of Service</a> and <a href="/privacy.pdf" style={{ textDecoration: 'underline' }}> Privacy Policy</a>.
        </div>
        {/* <br />
            <p />
            <div style={{fontFamily: '"Roboto Condensed", sans-serif', fontWeight: 300, fontSize: 14, textAlign: 'left', marginLeft: 25}}>
            <input type="checkbox" id="instructor" name="instructor" /> I want to instruct dance sessions!
              <br />
              <input type="checkbox" id="newsletter" name="newsletter" /> Want to subscribe to our newsletter?</div>
            <p />
            <div style={{fontFamily: '"Roboto Condensed", sans-serif', fontWeight: 300, fontSize: 15}}>
              <input type="checkbox" id="tosagree" name="tosagree" style={{paddingTop: 25, marginTop: 15}} />I agree to the Dance4Healing <a href="/terms.pdf" style={{textDecoration: 'underline'}}>Terms of Service</a> and
              <a href="/privacy.pdf" style={{textDecoration: 'underline'}}> Privacy Policy</a>.
              <br />
              <br />
            </div> */}
        <br />
        <br />
        <button type="submit" name="submit" id="submit" className="btn-lg register2">Sign Up Now</button>
      </form>
    )
  }
}

export default SignupForm;