"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.getRubberBandRect = exports.RubberBandXySelectorModifier = void 0;
var EasingFunctions_1 = require("../../node_modules/scichart/Core/Animations/EasingFunctions");
var Deleter_1 = require("../../node_modules/scichart/Core/Deleter");
var Point_1 = require("../../node_modules/scichart/Core/Point");
var Rect_1 = require("../../node_modules/scichart/Core/Rect");
var ChartModifierType_1 = require("../../node_modules/scichart/types/ChartModifierType");
var XyDirection_1 = require("../../node_modules/scichart/types/XyDirection");
var ZoomState_1 = require("../../node_modules/scichart/types/ZoomState");
var translate_1 = require("../../node_modules/scichart/utils/translate");
var RubberBandSvgRect_1 = require("../../node_modules/scichart/Charting/Visuals/RubberBandSvgRect/RubberBandSvgRect");
var ChartModifierBase2D_1 = require("../../node_modules/scichart/Charting/ChartModifiers/ChartModifierBase2D");
var constants_1 = require("../../node_modules/scichart/Charting/ChartModifiers/constants");
/** @ignore */
var MIN_DRAG_SENSITIVITY = 5;

var RubberBandXySelectorModifier = /** @class */ (function (_super) {
    __extends(RubberBandXySelectorModifier, _super);

    function RubberBandXySelectorModifier(options) {
        var _a, _b, _c, _d, _e, _f;
        var _this = _super.call(this, options) || this;
        _this.type = ChartModifierType_1.EChart2DModifierType.RubberBandXYZoom;
        /**
         * When true, the Zoom operations are animated. See also {@link animationDuration} and {@link easingFunction}
         */
        _this.isAnimated = true;
        /**
         * Defines the duration of animations when zooming in milliseconds
         */
        _this.animationDuration = 400;
        /**
         * Defines the easing function for animation. See {@link TEasingFn} for a range of functions
         */
        _this.easingFunction = EasingFunctions_1.easing.outExpo;
        _this.isClicked = false;
        _this.fillProperty = "#42b64933";
        _this.strokeProperty = "#42b64977";
        _this.strokeThicknessProperty = 2;
        _this.rangeSelectProperty = true;
        _this.fill = (_a = options === null || options === void 0 ? void 0 : options.fill) !== null && _a !== void 0 ? _a : _this.fillProperty;
        _this.stroke = (_b = options === null || options === void 0 ? void 0 : options.stroke) !== null && _b !== void 0 ? _b : _this.strokeProperty;
        _this.strokeThickness = (_c = options === null || options === void 0 ? void 0 : options.strokeThickness) !== null && _c !== void 0 ? _c : _this.strokeThicknessProperty;
        _this.rangeSelect = (_d = options === null || options === void 0 ? void 0 : options.rangeSelect) !== null && _d !== void 0 ? _d : _this.rangeSelectProperty;


        if ((options === null || options === void 0 ? void 0 : options.easingFunction) && typeof options.easingFunction === "string") {
            options.easingFunction = EasingFunctions_1.easing[options.easingFunction];
        }
        _this.easingFunction = (_f = options === null || options === void 0 ? void 0 : options.easingFunction) !== null && _f !== void 0 ? _f : EasingFunctions_1.easing.outExpo;

        return _this;
    }
    /**
     * @inheritDoc
     */
    RubberBandXySelectorModifier.prototype.applyTheme = function (themeProvider) {
        if (!this.testPropertyChanged(constants_1.PROPERTY.FILL)) {
            this.fill = themeProvider.rubberBandFillBrush;
        }
        if (!this.testPropertyChanged(constants_1.PROPERTY.STROKE)) {
            this.stroke = themeProvider.rubberBandStrokeBrush;
        }
    };
    /**
     * @inheritDoc
     */
    RubberBandXySelectorModifier.prototype.onAttach = function () {
        _super.prototype.onAttach.call(this);
        this.rubberBandRect = new RubberBandSvgRect_1.RubberBandSvgRect(this.parentSurface.domSvgContainer, this.fill, this.stroke, this.strokeThickness);

        //this.parentSurface.domChartRoot.addEventListener('SelectRange', e => console.log(e.detail));

    };
    /**
     * @inheritDoc
     */
    RubberBandXySelectorModifier.prototype.onDetach = function () {
        _super.prototype.onDetach.call(this);
        this.rubberBandRect = undefined;
    };
    /**
     * @inheritDoc
     */
    RubberBandXySelectorModifier.prototype.modifierMouseDown = function (args) {
        _super.prototype.modifierMouseDown.call(this, args);
        if (this.executeOn !== args.button) {
            return;
        }
        if (!this.isAttached) {
            throw new Error("Should not call RubberBandXyZoomModifier.modifierMouseDown if not attached");
        }
        this.parentSurface.setZoomState(ZoomState_1.EZoomState.UserZooming);
        var pointFromTrans = translate_1.translateFromCanvasToSeriesViewRect(args.mousePoint, this.parentSurface.seriesViewRect);
        if (pointFromTrans) {
            this.pointFrom = pointFromTrans;
            this.isClicked = true;
        }
    };
    /**
     * @inheritDoc
     */
    RubberBandXySelectorModifier.prototype.modifierMouseMove = function (args) {
        _super.prototype.modifierMouseMove.call(this, args);
        var seriesViewRect = this.parentSurface.seriesViewRect;
        if (this.isClicked && this.rangeSelect) {
            this.pointTo = translate_1.translateFromCanvasToSeriesViewRect(Rect_1.Rect.clipPointToRect(args.mousePoint, seriesViewRect), seriesViewRect);
            var _a = getRubberBandRect(this.pointFrom, this.pointTo, this.xyDirection, this.parentSurface.seriesViewRect), x = _a.x, right = _a.right, y = _a.y, bottom = _a.bottom;
            this.rubberBandRect.isHidden = false;
            this.rubberBandRect.x1 = translate_1.translateToNotScaled(x);
            this.rubberBandRect.x2 = translate_1.translateToNotScaled(right);
            this.rubberBandRect.y1 = translate_1.translateToNotScaled(y);
            this.rubberBandRect.y2 = translate_1.translateToNotScaled(bottom);
        }
    };
    /**
     * @inheritDoc
     */
    RubberBandXySelectorModifier.prototype.modifierMouseUp = function (args) {
        _super.prototype.modifierMouseUp.call(this, args);
        if (this.executeOn !== args.button) {
            return;
        }
        if (this.isClicked) {
            var seriesViewRect = this.parentSurface.seriesViewRect;
            this.pointTo = translate_1.translateFromCanvasToSeriesViewRect(Rect_1.Rect.clipPointToRect(args.mousePoint, seriesViewRect), seriesViewRect);
            var _a = getRubberBandRect(this.pointFrom, this.pointTo, this.xyDirection, this.parentSurface.seriesViewRect), x = _a.x, right = _a.right, y = _a.y, bottom = _a.bottom;
            this.isClicked = false;


            const xAxis = this.parentSurface.xAxes.get(0); // Type AxisBase2D
            const coordCalc = xAxis.getCurrentCoordinateCalculator();


            const start = coordCalc.getDataValue(this.pointFrom.x)
            const end = coordCalc.getDataValue(this.pointTo.x)

            if (this.rangeSelect) {
                //this.rubberBandRect.isHidden = true;
                if (this.calculateDraggedDistance() > MIN_DRAG_SENSITIVITY) {
                    //this.performZoom(new Point_1.Point(x, y), new Point_1.Point(right, bottom));
                    const event = new CustomEvent('SelectRange', { detail: [start, end] });
                    //this.parentSurface.domChartRoot.dispatchEvent(event);
                    document.dispatchEvent(event);
                }
                else {
                    const event = new CustomEvent('SelectRange', { detail: [start, start] });
                    //this.parentSurface.domChartRoot.dispatchEvent(event);
                    document.dispatchEvent(event);
                }
                this.rubberBandRect.isHidden = true;
            }
            else {
                const event = new CustomEvent('SelectRange', { detail: [start, start] });
                //this.parentSurface.domChartRoot.dispatchEvent(event);
                document.dispatchEvent(event);
            }

           
           
        }
    };
    Object.defineProperty(RubberBandXySelectorModifier.prototype, "strokeThickness", {
        // PROPERTIES
        /**
         * Get the stroke thickness for {@link RubberBandSvgRect}
         */
        get: function () {
            return this.strokeThicknessProperty;
        },
        /**
         * Set the stroke thickness for {@link RubberBandSvgRect}
         */
        set: function (value) {
            this.strokeThicknessProperty = value;
            this.notifyPropertyChanged(constants_1.PROPERTY.STROKE_THICKNESS);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RubberBandXySelectorModifier.prototype, "rangeSelect", {
        // PROPERTIES
        /**
         * Get the stroke thickness for {@link RubberBandSvgRect}
         */
        get: function () {
            return this.rangeSelectProperty;
        },
        /**
         * Set the stroke thickness for {@link RubberBandSvgRect}
         */
        set: function (value) {
            this.rangeSelectProperty = value;
     
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RubberBandXySelectorModifier.prototype, "stroke", {
        /**
         * Get the stroke for {@link RubberBandSvgRect}
         */
        get: function () {
            return this.strokeProperty;
        },
        /**
         * Set the stroke for {@link RubberBandSvgRect}
         */
        set: function (value) {
            this.strokeProperty = value;
            this.notifyPropertyChanged(constants_1.PROPERTY.STROKE);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RubberBandXySelectorModifier.prototype, "fill", {
        /**
         * Get the fill color for {@link RubberBandSvgRect}
         */
        get: function () {
            return this.fillProperty;
        },
        /**
         * Set the fill color for {@link RubberBandSvgRect}
         */
        set: function (value) {
            this.fillProperty = value;
            this.notifyPropertyChanged(constants_1.PROPERTY.FILL);
        },
        enumerable: false,
        configurable: true
    });
    RubberBandXySelectorModifier.prototype.toJSON = function () {
        var json = _super.prototype.toJSON.call(this);
        var options = {
            fill: this.fill,
            stroke: this.stroke,
            strokeThickness: this.strokeThickness,
            rangeSelect: this.rangeSelect
        };
        Object.assign(json.options, options);
        return json;
    };
   
    RubberBandXySelectorModifier.prototype.notifyPropertyChanged = function (propertyName) {
        _super.prototype.notifyPropertyChanged.call(this, propertyName);
        this.updateRubberBandRect();
    };
    RubberBandXySelectorModifier.prototype.calculateDraggedDistance = function () {
        var diffX = Math.pow((this.pointFrom.x - this.pointTo.x), 2);
        var diffY = Math.pow((this.pointFrom.y - this.pointTo.y), 2);
        return Math.sqrt(diffX + diffY);
    };
    RubberBandXySelectorModifier.prototype.updateRubberBandRect = function () {
        if (this.parentSurface) {
            this.rubberBandRect = Deleter_1.deleteSafe(this.rubberBandRect);
            this.rubberBandRect = new RubberBandSvgRect_1.RubberBandSvgRect(this.parentSurface.domSvgContainer, this.fill, this.stroke, this.strokeThickness);
        }
    };
    return RubberBandXySelectorModifier;
}(ChartModifierBase2D_1.ChartModifierBase2D));
exports.RubberBandXySelectorModifier = RubberBandXySelectorModifier;
/**
 * Given the starting and end mouse-point, computes a rectangle to perform zoom over. Takes into account the xyDirection
 * @param pointFrom the starting point of the mouse
 * @param pointTo the end point of the mouse
 * @param xyDirection the XyDirection
 */
function getRubberBandRect(pointFrom, pointTo, xyDirection, viewportRect) {
    var x1 = pointTo.x <= pointFrom.x ? pointTo.x : pointFrom.x;
    var x2 = pointTo.x <= pointFrom.x ? pointFrom.x : pointTo.x;
    var y1 = pointTo.y <= pointFrom.y ? pointTo.y : pointFrom.y;
    var y2 = pointTo.y <= pointFrom.y ? pointFrom.y : pointTo.y;

    y1 = 0;
    y2 = viewportRect.height;

    return Rect_1.Rect.createWithPoints(new Point_1.Point(x1, y1), new Point_1.Point(x2, y2));
}
exports.getRubberBandRect = getRubberBandRect;
