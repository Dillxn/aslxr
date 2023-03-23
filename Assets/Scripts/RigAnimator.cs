using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediapipe.Unity.Holistic
{
    public class RigAnimator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _poseConstraintParents;
        [SerializeField]
        private GameObject _leftHandConstraintParents;
        [SerializeField]
        private GameObject _rightHandConstraintParents;
        [SerializeField]
        private GameObject _model;
        [SerializeField]        
        
        private LandmarkList poseWorldLandmarksCache;
        private LandmarkList leftHandWorldLandmarksCache;
        private LandmarkList rightHandWorldLandmarksCache;
        public void animate(LandmarkList poseWorldLandmarks, LandmarkList leftHandWorldLandmarks, LandmarkList rightHandWorldLandmarks ) {
            // we impplement a cache because not all landmarks are available in every frame
            if (poseWorldLandmarks != null) {
                poseWorldLandmarksCache = cloneLandmarkList(poseWorldLandmarks);
            }
            if (leftHandWorldLandmarks != null) {
                leftHandWorldLandmarksCache = cloneLandmarkList(leftHandWorldLandmarks);
            }
            if (rightHandWorldLandmarks != null) {
                rightHandWorldLandmarksCache = cloneLandmarkList(rightHandWorldLandmarks);
            }
            if (poseWorldLandmarksCache == null || leftHandWorldLandmarksCache == null || rightHandWorldLandmarksCache == null) {
                return;
            }
            
            animatePose(poseWorldLandmarksCache);
            animateHand(rightHandWorldLandmarksCache, "right");
            animateHand(leftHandWorldLandmarksCache, "left");
        }
        
         // cloneLandmarkList() - Clones a landmark list
        private LandmarkList cloneLandmarkList(LandmarkList landmarkList) {
            var landmarkListCopy = new LandmarkList();
            foreach (var landmark in landmarkList.Landmark) {
                var landmarkCopy = new Landmark();
                landmarkCopy.X = landmark.X;
                landmarkCopy.Y = landmark.Y;
                landmarkCopy.Z = landmark.Z;
                landmarkListCopy.Landmark.Add(landmarkCopy);
            }
            return landmarkListCopy;
        }
        
        // animateHand() - Animates the parents of the model constraints
        private void animateHand(LandmarkList rightHandWorldLandmarks, string handType) {
            var landmarks = cloneLandmarkList(rightHandWorldLandmarks).Landmark;

            
            var wrist = landmarks[0];
            var thumb_cmc = landmarks[1];
            var thumb_mcp = landmarks[2];
            var thumb_ip = landmarks[3];
            var thumb_tip = landmarks[4];
            var index_finger_mcp = landmarks[5];
            var index_finger_pip = landmarks[6];
            var index_finger_dip = landmarks[7];
            var index_finger_tip = landmarks[8];
            var middle_finger_mcp = landmarks[9];
            var middle_finger_pip = landmarks[10];
            var middle_finger_dip = landmarks[11];
            var middle_finger_tip = landmarks[12];
            var ring_finger_mcp = landmarks[13];
            var ring_finger_pip = landmarks[14];
            var ring_finger_dip = landmarks[15];
            var ring_finger_tip = landmarks[16];
            var pinky_mcp = landmarks[17];
            var pinky_pip = landmarks[18];
            var pinky_dip = landmarks[19];
            var pinky_tip = landmarks[20];
            
            // invert y axis for all landmarks
            foreach (var landmark in landmarks) {
                landmark.Y = -landmark.Y;
            }
        
            // position constraint parents
            GameObject handConstraintParents;
            Transform poseWrist;
            
            if (handType == "right") {
                handConstraintParents = _rightHandConstraintParents;
                poseWrist = _poseConstraintParents.transform.Find("right_wrist");
            } else {
                handConstraintParents = _leftHandConstraintParents;
                poseWrist = _poseConstraintParents.transform.Find("left_wrist");
            }
            
            handConstraintParents.transform.Find("wrist").localPosition = new Vector3(wrist.X, wrist.Y, wrist.Z);
            handConstraintParents.transform.Find("thumb_cmc").localPosition = new Vector3(thumb_cmc.X, thumb_cmc.Y, thumb_cmc.Z);
            handConstraintParents.transform.Find("thumb_mcp").localPosition = new Vector3(thumb_mcp.X, thumb_mcp.Y, thumb_mcp.Z);
            handConstraintParents.transform.Find("thumb_ip").localPosition = new Vector3(thumb_ip.X, thumb_ip.Y, thumb_ip.Z);
            handConstraintParents.transform.Find("thumb_tip").localPosition = new Vector3(thumb_tip.X, thumb_tip.Y, thumb_tip.Z);
            handConstraintParents.transform.Find("index_finger_mcp").localPosition = new Vector3(index_finger_mcp.X, index_finger_mcp.Y, index_finger_mcp.Z);
            handConstraintParents.transform.Find("index_finger_pip").localPosition = new Vector3(index_finger_pip.X, index_finger_pip.Y, index_finger_pip.Z);
            handConstraintParents.transform.Find("index_finger_dip").localPosition = new Vector3(index_finger_dip.X, index_finger_dip.Y, index_finger_dip.Z);
            handConstraintParents.transform.Find("index_finger_tip").localPosition = new Vector3(index_finger_tip.X, index_finger_tip.Y, index_finger_tip.Z);
            handConstraintParents.transform.Find("middle_finger_mcp").localPosition = new Vector3(middle_finger_mcp.X, middle_finger_mcp.Y, middle_finger_mcp.Z);
            handConstraintParents.transform.Find("middle_finger_pip").localPosition = new Vector3(middle_finger_pip.X, middle_finger_pip.Y, middle_finger_pip.Z);
            handConstraintParents.transform.Find("middle_finger_dip").localPosition = new Vector3(middle_finger_dip.X, middle_finger_dip.Y, middle_finger_dip.Z);
            handConstraintParents.transform.Find("middle_finger_tip").localPosition = new Vector3(middle_finger_tip.X, middle_finger_tip.Y, middle_finger_tip.Z);
            handConstraintParents.transform.Find("ring_finger_mcp").localPosition = new Vector3(ring_finger_mcp.X, ring_finger_mcp.Y, ring_finger_mcp.Z);
            handConstraintParents.transform.Find("ring_finger_pip").localPosition = new Vector3(ring_finger_pip.X, ring_finger_pip.Y, ring_finger_pip.Z);
            handConstraintParents.transform.Find("ring_finger_dip").localPosition = new Vector3(ring_finger_dip.X, ring_finger_dip.Y, ring_finger_dip.Z);
            handConstraintParents.transform.Find("ring_finger_tip").localPosition = new Vector3(ring_finger_tip.X, ring_finger_tip.Y, ring_finger_tip.Z);
            handConstraintParents.transform.Find("pinky_mcp").localPosition = new Vector3(pinky_mcp.X, pinky_mcp.Y, pinky_mcp.Z);
            handConstraintParents.transform.Find("pinky_pip").localPosition = new Vector3(pinky_pip.X, pinky_pip.Y, pinky_pip.Z);
            handConstraintParents.transform.Find("pinky_dip").localPosition = new Vector3(pinky_dip.X, pinky_dip.Y, pinky_dip.Z);
            handConstraintParents.transform.Find("pinky_tip").localPosition = new Vector3(pinky_tip.X, pinky_tip.Y, pinky_tip.Z);
        
            // position _rightHandConstraintParent to poseWrist position minus wrist position
            var poseWristPosition = poseWrist.position;
            handConstraintParents.transform.position = new Vector3(poseWristPosition.x - wrist.X, poseWristPosition.y - wrist.Y, poseWristPosition.z - wrist.Z);


            /* Rotation of wrist */
             // Calculate two vectors from the wrist landmark to other landmarks (index_finger_mcp and pinky_mcp)
            Vector3 wristToIndexFinger = new Vector3(index_finger_mcp.X - wrist.X, index_finger_mcp.Y - wrist.Y, index_finger_mcp.Z - wrist.Z);
            Vector3 wristToPinky = new Vector3(pinky_mcp.X - wrist.X, pinky_mcp.Y - wrist.Y, pinky_mcp.Z - wrist.Z);

            // Normalize the vectors
            wristToIndexFinger.Normalize();
            wristToPinky.Normalize();

            // Calculate the cross product of the two vectors to get a normal vector
            Vector3 normal = Vector3.Cross(wristToIndexFinger, wristToPinky);

            // Calculate the angle between the vectors using the dot product
            float angle = Mathf.Acos(Vector3.Dot(wristToIndexFinger, wristToPinky)) * Mathf.Rad2Deg;

            // Use Quaternion.LookRotation to create a rotation that aligns the model's hand with the landmarks
            Quaternion wristRotation = Quaternion.LookRotation(wristToIndexFinger, normal);
            handConstraintParents.transform.Find("wrist").localRotation = wristRotation;
            
            /* Rotation of fingers */
            handConstraintParents.transform.Find("thumb_cmc").transform.LookAt(handConstraintParents.transform.Find("thumb_mcp"));
            handConstraintParents.transform.Find("thumb_mcp").transform.LookAt(handConstraintParents.transform.Find("thumb_ip"));
            handConstraintParents.transform.Find("thumb_ip").transform.LookAt(handConstraintParents.transform.Find("thumb_tip"));
            handConstraintParents.transform.Find("index_finger_mcp").transform.LookAt(handConstraintParents.transform.Find("index_finger_pip"));
            handConstraintParents.transform.Find("index_finger_pip").transform.LookAt(handConstraintParents.transform.Find("index_finger_dip"));
            handConstraintParents.transform.Find("index_finger_dip").transform.LookAt(handConstraintParents.transform.Find("index_finger_tip"));
            handConstraintParents.transform.Find("middle_finger_mcp").transform.LookAt(handConstraintParents.transform.Find("middle_finger_pip"));
            handConstraintParents.transform.Find("middle_finger_pip").transform.LookAt(handConstraintParents.transform.Find("middle_finger_dip"));
            handConstraintParents.transform.Find("middle_finger_dip").transform.LookAt(handConstraintParents.transform.Find("middle_finger_tip"));
            handConstraintParents.transform.Find("ring_finger_mcp").transform.LookAt(handConstraintParents.transform.Find("ring_finger_pip"));
            handConstraintParents.transform.Find("ring_finger_pip").transform.LookAt(handConstraintParents.transform.Find("ring_finger_dip"));
            handConstraintParents.transform.Find("ring_finger_dip").transform.LookAt(handConstraintParents.transform.Find("ring_finger_tip"));
            handConstraintParents.transform.Find("pinky_mcp").transform.LookAt(handConstraintParents.transform.Find("pinky_pip"));
            handConstraintParents.transform.Find("pinky_pip").transform.LookAt(handConstraintParents.transform.Find("pinky_dip"));
            handConstraintParents.transform.Find("pinky_dip").transform.LookAt(handConstraintParents.transform.Find("pinky_tip"));
            
        }

        // animatePose() - Animates the parents of the model constraints
        private void animatePose(LandmarkList poseWorldLandmarks) {
            var landmarks = cloneLandmarkList(poseWorldLandmarks).Landmark;
            
            // invert y axis for all landmarks
            foreach (var landmark in landmarks) {
                landmark.Y = -landmark.Y;
            }
            
            var nose = landmarks[0];
            var left_eye_inner = landmarks[1];
            var left_eye = landmarks[2];
            var left_eye_outer = landmarks[3];
            var right_eye_inner = landmarks[4];
            var right_eye = landmarks[5];
            var right_eye_outer = landmarks[6];
            var left_ear = landmarks[7];
            var right_ear = landmarks[8];
            var mouth_left = landmarks[9];
            var mouth_right = landmarks[10];
            var left_shoulder = landmarks[11];
            var right_shoulder = landmarks[12];
            var left_elbow = landmarks[13];
            var right_elbow = landmarks[14];
            var left_wrist = landmarks[15];
            var right_wrist = landmarks[16];
            var left_pinky = landmarks[17];
            var right_pinky = landmarks[18];
            var left_index = landmarks[19];
            var right_index = landmarks[20];
            var left_thumb = landmarks[21];
            var right_thumb = landmarks[22];
            var left_hip = landmarks[23];
            var right_hip = landmarks[24];
            var left_knee = landmarks[25];
            var right_knee = landmarks[26];
            var left_ankle = landmarks[27];
            var right_ankle = landmarks[28];
            var left_heel = landmarks[29];
            var right_heel = landmarks[30];
            var left_foot_index = landmarks[31];
            var right_foot_index = landmarks[32];
            
            // extrapolate other points
            var hip_center = new NormalizedLandmark();
            hip_center.X = (left_hip.X + right_hip.X) / 2;
            hip_center.Y = (left_hip.Y + right_hip.Y) / 2;
            hip_center.Z = (left_hip.Z + right_hip.Z) / 2;
            
            var shoulder_center = new NormalizedLandmark();
            shoulder_center.X = (left_shoulder.X + right_shoulder.X) / 2;
            shoulder_center.Y = (left_shoulder.Y + right_shoulder.Y) / 2;
            shoulder_center.Z = (left_shoulder.Z + right_shoulder.Z) / 2;
            
            var middle_body_center = new NormalizedLandmark();
            middle_body_center.X = (hip_center.X + shoulder_center.X) / 2;
            middle_body_center.Y = (hip_center.Y + shoulder_center.Y) / 2;
            middle_body_center.Z = (hip_center.Z + shoulder_center.Z) / 2;
            
            var upper_body_center = new NormalizedLandmark();
            upper_body_center.X = (middle_body_center.X + shoulder_center.X) / 2;
            upper_body_center.Y = (middle_body_center.Y + shoulder_center.Y) / 2;
            upper_body_center.Z = (middle_body_center.Z + shoulder_center.Z) / 2;
            
            var lower_body_center = new NormalizedLandmark();
            lower_body_center.X = (middle_body_center.X + hip_center.X) / 2;
            lower_body_center.Y = (middle_body_center.Y + hip_center.Y) / 2;
            lower_body_center.Z = (middle_body_center.Z + hip_center.Z) / 2;
            

            // position constraint parents
            _poseConstraintParents.transform.Find("nose").transform.localPosition = new Vector3(nose.X, nose.Y, nose.Z);
            _poseConstraintParents.transform.Find("left_shoulder").transform.localPosition = new Vector3(left_shoulder.X, left_shoulder.Y, left_shoulder.Z);
            _poseConstraintParents.transform.Find("right_shoulder").transform.localPosition = new Vector3(right_shoulder.X, right_shoulder.Y, right_shoulder.Z);
            _poseConstraintParents.transform.Find("left_elbow").transform.localPosition = new Vector3(left_elbow.X, left_elbow.Y, left_elbow.Z);
            _poseConstraintParents.transform.Find("right_elbow").transform.localPosition = new Vector3(right_elbow.X, right_elbow.Y, right_elbow.Z);
            _poseConstraintParents.transform.Find("left_wrist").transform.localPosition = new Vector3(left_wrist.X, left_wrist.Y, left_wrist.Z);
            _poseConstraintParents.transform.Find("right_wrist").transform.localPosition = new Vector3(right_wrist.X, right_wrist.Y, right_wrist.Z);
            _poseConstraintParents.transform.Find("left_hip").transform.localPosition = new Vector3(left_hip.X, left_hip.Y, left_hip.Z);
            _poseConstraintParents.transform.Find("right_hip").transform.localPosition = new Vector3(right_hip.X, right_hip.Y, right_hip.Z);
            _poseConstraintParents.transform.Find("left_knee").transform.localPosition = new Vector3(left_knee.X, left_knee.Y, left_knee.Z);
            _poseConstraintParents.transform.Find("right_knee").transform.localPosition = new Vector3(right_knee.X, right_knee.Y, right_knee.Z);
            _poseConstraintParents.transform.Find("left_ankle").transform.localPosition = new Vector3(left_ankle.X, left_ankle.Y, left_ankle.Z);
            _poseConstraintParents.transform.Find("right_ankle").transform.localPosition = new Vector3(right_ankle.X, right_ankle.Y, right_ankle.Z);
            _poseConstraintParents.transform.Find("left_heel").transform.localPosition = new Vector3(left_heel.X, left_heel.Y, left_heel.Z);
            _poseConstraintParents.transform.Find("right_heel").transform.localPosition = new Vector3(right_heel.X, right_heel.Y, right_heel.Z);
            _poseConstraintParents.transform.Find("left_foot_index").transform.localPosition = new Vector3(left_foot_index.X, left_foot_index.Y, left_foot_index.Z);
            _poseConstraintParents.transform.Find("right_foot_index").transform.localPosition = new Vector3(right_foot_index.X, right_foot_index.Y, right_foot_index.Z);
            _poseConstraintParents.transform.Find("hip_center").transform.localPosition = new Vector3(hip_center.X, hip_center.Y, hip_center.Z);
            _poseConstraintParents.transform.Find("shoulder_center").transform.localPosition = new Vector3(shoulder_center.X, shoulder_center.Y, shoulder_center.Z);
            _poseConstraintParents.transform.Find("middle_body_center").transform.localPosition = new Vector3(middle_body_center.X, middle_body_center.Y, middle_body_center.Z);
            _poseConstraintParents.transform.Find("upper_body_center").transform.localPosition = new Vector3(upper_body_center.X, upper_body_center.Y, upper_body_center.Z);
            _poseConstraintParents.transform.Find("lower_body_center").transform.localPosition = new Vector3(lower_body_center.X, lower_body_center.Y, lower_body_center.Z);
            _poseConstraintParents.transform.Find("right_index").transform.localPosition = new Vector3(right_index.X, right_index.Y, right_index.Z);
            _poseConstraintParents.transform.Find("right_thumb").transform.localPosition = new Vector3(right_thumb.X, right_thumb.Y, right_thumb.Z);
            _poseConstraintParents.transform.Find("right_pinky").transform.localPosition = new Vector3(right_pinky.X, right_pinky.Y, right_pinky.Z);
            
            // rotate constraint parents
            _poseConstraintParents.transform.Find("lower_body_center").transform.LookAt(_poseConstraintParents.transform.Find("middle_body_center").transform);
            _poseConstraintParents.transform.Find("middle_body_center").transform.LookAt(_poseConstraintParents.transform.Find("upper_body_center").transform);
            _poseConstraintParents.transform.Find("upper_body_center").transform.LookAt(_poseConstraintParents.transform.Find("shoulder_center").transform);
            _poseConstraintParents.transform.Find("left_shoulder").transform.LookAt(_poseConstraintParents.transform.Find("left_elbow").transform);
            _poseConstraintParents.transform.Find("left_elbow").transform.LookAt(_poseConstraintParents.transform.Find("left_wrist").transform);
            _poseConstraintParents.transform.Find("right_shoulder").transform.LookAt(_poseConstraintParents.transform.Find("right_elbow").transform);
            _poseConstraintParents.transform.Find("right_elbow").transform.LookAt(_poseConstraintParents.transform.Find("right_wrist").transform);
            
            

        }
    }
}