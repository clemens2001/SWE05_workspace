package at.fhooe.me.android.test.sensors

import android.app.Activity
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import at.fhooe.me.android.test.sensors.databinding.ActivityMainBinding

const val TAG: String = "Sensor-Test"

class MainActivity : Activity(), SensorEventListener {

    private lateinit var mSensorMgr: SensorManager
    lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // mSensorMgr = getSystemService(SENSOR_SERVICE) as SensorManager
        mSensorMgr = getSystemService(SensorManager::class.java)

        binding.accOnOffSwitch.setOnCheckedChangeListener { _button, _isChecked ->
            if (_isChecked) {
                mSensorMgr.getDefaultSensor(Sensor.TYPE_ACCELEROMETER).also {
                    mSensorMgr.registerListener(this, it, SensorManager.SENSOR_DELAY_NORMAL)
                }
            } else {
                mSensorMgr.unregisterListener(this)
            }
        }
    }

    override fun onPause() {
        super.onPause()
        mSensorMgr.unregisterListener(this)
    }

    override fun onSensorChanged(_event: SensorEvent?) {
        var values: FloatArray = _event?.values ?: FloatArray(0)
        when (_event?.sensor?.type) {
            Sensor.TYPE_ACCELEROMETER -> {
                binding.outputX.text = values[0].toString()
                binding.outputY.text = values[1].toString()
                binding.outputZ.text = values[2].toString()
            }
            else -> {
                Log.d(TAG, "MainActivity::onSensorChanged unexpected sensor ID ${_event?.sensor?.id} encountered")
            }
        }
        Log.d(TAG, "MainActivity::onSensorChanged x --> " + values[0])
        Log.d(TAG, "MainActivity::onSensorChanged y --> " + values[1])
        Log.d(TAG, "MainActivity::onSensorChanged z --> " + values[2])
    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {
        Log.d(TAG, "MainActivity::onAccuracyChanged")
    }
}